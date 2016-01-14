using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Net.Mime;

namespace RDScanner
{
    public partial class Form1 : Form
    {
        XmlFile xmlFile = new XmlFile();
        List<Mod> carsList = new List<Mod>();
        List<Mod> tracksList = new List<Mod>();
        List<Mod> skinsList = new List<Mod>();
        List<Mod> miscList = new List<Mod>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            xmlFile.name = "RDFiles.xml";
            xmlFile.path = @"C:\Users\Martin\Dropbox\RDScanner";
            xmlFile.fullName = @"C:\Users\Martin\Dropbox\RDScanner\RDFiles.xml";

            if (!File.Exists(xmlFile.fullName))
                CreateXmlFile(xmlFile);
        }

        private void carsButton_Click(object sender, EventArgs e)
        {
            Task.Run(() => GetModList("cars"));
        }

        private void tracksButton_Click(object sender, EventArgs e)
        {
            Task.Run(() => GetModList("tracks"));
        }

        private void skinsButton_Click(object sender, EventArgs e)
        {
            Task.Run(() => GetModList("skins"));
        }

        private void miscButton_Click(object sender, EventArgs e)
        {
            Task.Run(() => GetModList("misc"));
        }

        private void allButton_Click(object sender, EventArgs e)
        {
            CreateXmlFile(xmlFile);
            Task.Run(() => GetModList("cars"));
            Task.Run(() => GetModList("tracks"));
            Task.Run(() => GetModList("skins"));
            Task.Run(() => GetModList("misc"));
        }

        public void GetModList(string type)
        {
            lock(this)
            {
                if (!File.Exists(xmlFile.fullName))
                    CreateXmlFile(xmlFile);

                string url = "";
                if (type == "cars")
                    url = "http://www.racedepartment.com/downloads/categories/sce-cars.82/";
                else if (type == "tracks")
                    url = "http://www.racedepartment.com/downloads/categories/sce-tracks.22/";
                else if (type == "skins")
                    url = "http://www.racedepartment.com/downloads/categories/sce-skins.23/";
                else if (type == "misc")
                    url = "http://www.racedepartment.com/downloads/categories/sce-misc.24/";
                WebClient wc = new WebClient();
                string html = wc.DownloadString(url);

                MatchCollection mColl = Regex.Matches(html, "<span class=\"pageNavHeader\">Page 1 of (.+?)</span>", RegexOptions.Singleline);
                int pageCount = Convert.ToInt32(mColl[0].Groups[1].Value);

                for (int i = 1; i <= pageCount; i++)
                {
                    html = wc.DownloadString(url + "?page=" + i);
                    MatchCollection mName = Regex.Matches(html, "<h3 class=\"title\">\\s*(.+?)<div class=\"listBlock resourceStats\">", RegexOptions.Singleline);

                    foreach (Match m in mName)
                    {
                        Mod mod = new Mod();
                        string substring = m.Groups[1].Value;
                        string pat;
                        string subhtml;
                        Regex r;
                        Match submatch;

                        pat = ">(.+?)</a>";
                        r = new Regex(pat, RegexOptions.Singleline);
                        submatch = r.Match(substring);
                        mod.name = HttpUtility.HtmlDecode(submatch.Groups[1].Value);


                        pat = "\"version\">(.+?)</span>";
                        r = new Regex(pat, RegexOptions.Singleline);
                        submatch = r.Match(substring);
                        mod.version = submatch.Groups[1].Value;

                        pat = "\"auto\">(.+?)</a>";
                        r = new Regex(pat, RegexOptions.Singleline);
                        submatch = r.Match(substring);
                        mod.author = submatch.Groups[1].Value;

                        pat = "([a-zA-Z]{3}\\s[0-9]{1,2},\\s[0-9]{4})";
                        r = new Regex(pat, RegexOptions.Singleline);
                        submatch = r.Match(substring);
                        mod.date = submatch.Groups[1].Value;

                        pat = "\"(.+?)/\"";
                        r = new Regex(pat, RegexOptions.Singleline);
                        submatch = r.Match(substring);

                        subhtml = wc.DownloadString("http://www.racedepartment.com/" + submatch.Groups[1].Value);

                        pat = "<label\\sclass=\"downloadButton\\s\">\\s*<a\\shref=\"(.+?)\"";
                        r = new Regex(pat, RegexOptions.Singleline);
                        submatch = r.Match(subhtml);
                        mod.downloadLink = "http://www.racedepartment.com/" + submatch.Groups[1].Value;

                        mod.fileName = GetFileName(mod.downloadLink);

                        pat = "<small\\sclass=\"minorText\">(.+?)\\sMB";
                        r = new Regex(pat, RegexOptions.Singleline);
                        submatch = r.Match(subhtml);
                        mod.size = submatch.Groups[1].Value;

                        if (mod.size == "")
                            mod.size = "<1.0";

                        mod.type = type;

                        NewXmlEntry(mod);
                        switch (type)
                        {
                            case "cars":
                                carsLabel.Invoke((MethodInvoker)delegate { carsLabel.Text = (Convert.ToInt32(carsLabel.Text) + 1).ToString(); });
                                break;
                            case "tracks":
                                tracksLabel.Invoke((MethodInvoker)delegate { tracksLabel.Text = (Convert.ToInt32(tracksLabel.Text) + 1).ToString(); });
                                break;
                            case "skins":
                                skinsLabel.Invoke((MethodInvoker)delegate { skinsLabel.Text = (Convert.ToInt32(skinsLabel.Text) + 1).ToString(); });
                                break;
                            case "misc":
                                miscLabel.Invoke((MethodInvoker)delegate { miscLabel.Text = (Convert.ToInt32(miscLabel.Text) + 1).ToString(); });
                                break;
                        }
                    }
                }
            }
        }

        private string GetFileName(string downloadLink)
        {
            string fileName = "";
            using (WebClient wc = new WebClient())
            {
                Uri url = new Uri(downloadLink);
                Stream myStream = wc.OpenRead(downloadLink);
                string header_contentDisposition = wc.ResponseHeaders["content-disposition"];
                fileName = new ContentDisposition(header_contentDisposition).FileName;
                myStream.Close();
            }
            return fileName;
        }

        private void CreateXmlFile(XmlFile xmlFile)
        {
            Directory.CreateDirectory(xmlFile.path);
            //File.Create(xmlFile.fullName);
            XDocument xmlDoc = new XDocument(
                new XElement("root",
                new XElement("cars"),
                new XElement("tracks"),
                new XElement("skins"),
                new XElement("misc")
                )
                );
            xmlDoc.Save(xmlFile.fullName);
        }

        private void NewXmlEntry(Mod mod)
        {
            XDocument xmlDoc = XDocument.Load(xmlFile.fullName);
            XElement cars = xmlDoc.Element("root").Element("cars");
            XElement tracks = xmlDoc.Element("root").Element("tracks");
            XElement skins = xmlDoc.Element("root").Element("skins");
            XElement misc = xmlDoc.Element("root").Element("misc");
            switch (mod.type)
            {
                case "cars":
                    cars.Add(new XElement("mod",
                        new XElement("name", mod.name),
                        new XElement("version", mod.version),
                        new XElement("author", mod.author),
                        new XElement("downloadLink", mod.downloadLink),
                        new XElement("fileName", mod.fileName),
                        new XElement("size", mod.size),
                        new XElement("date", mod.date)));
                    break;
                case "tracks":
                    tracks.Add(new XElement("mod",
                        new XElement("name", mod.name),
                        new XElement("version", mod.version),
                        new XElement("author", mod.author),
                        new XElement("downloadLink", mod.downloadLink),
                        new XElement("fileName", mod.fileName),
                        new XElement("size", mod.size),
                        new XElement("date", mod.date)));
                    break;
                case "skins":
                    skins.Add(new XElement("mod",
                        new XElement("name", mod.name),
                        new XElement("version", mod.version),
                        new XElement("author", mod.author),
                        new XElement("downloadLink", mod.downloadLink),
                        new XElement("fileName", mod.fileName),
                        new XElement("size", mod.size),
                        new XElement("date", mod.date)));
                    break;
                case "misc":
                    misc.Add(new XElement("mod",
                        new XElement("name", mod.name),
                        new XElement("version", mod.version),
                        new XElement("author", mod.author),
                        new XElement("downloadLink", mod.downloadLink),
                        new XElement("fileName", mod.fileName),
                        new XElement("size", mod.size),
                        new XElement("date", mod.date)));
                    break;
                default:
                    break;
            }
            xmlDoc.Save(xmlFile.fullName);
        }
    }

    public class XmlFile
    {
        public string   name,
                        path,
                        fullName;
    }

    public class Mod
    {
        public string   name,
                        version,
                        author,
                        downloadLink,
                        fileName,
                        size,
                        type,
                        date;
    }
}

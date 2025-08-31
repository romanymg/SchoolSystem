using System.IO.Compression;
using System.Xml.Linq;
using static Common.Models.SchoolModels;

namespace BAL.Services
{
    public class SchoolIntegrationService
    {
        public XDocument LoadXmlAsync()
        {
            var url = "https://kingsthecrown.isamshosting.cloud/api/batch/1.0/xml.ashx?apiKey=0E01C564-5AAE-4944-8B07-DAAC8A909F9F";
            using var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            return XDocument.Parse(response.Content.ReadAsStringAsync().Result);
        }
        public List<Contact> GetContacts(XDocument xDoc)
        {
            return xDoc.Descendants("Contact")
                .Select(c => new Contact
                {
                    Id = (int)c.Attribute("Id"),
                    Forename = (string)c.Element("Forename"),
                    MiddleNames = (string)c.Element("MiddleNames"),
                    Surname = (string)c.Element("Surname"),
                    Title = (string)c.Element("Title"),
                    EmailAddress = (string)c.Element("EmailAddress"),
                    Telephone = (string)c.Element("Telephone"),
                    Relationship = (string)c.Element("RelationshipRaw"),
                    Country = (string)c.Element("Address")?.Element("Country"),
                    PupilIds = c.Descendants("Pupil").Select(p => (string)p.Element("SchoolId")).ToList()
                }).ToList();
        }
        public List<Pupil> GetPupils(XDocument xDoc)
        {

            return xDoc.Descendants("CurrentPupils").Descendants("Pupil")
                .Select(p => new Pupil
                {
                    Id = (int)p.Attribute("Id"),
                    SchoolId = (string)p.Element("SchoolId"),
                    Forename = (string)p.Element("Forename"),
                    Surname = (string)p.Element("Surname"),
                    Fullname = (string)p.Element("Fullname"),
                    DivisionName = (string)p.Element("DivisionName"),
                    AcademicHouse = (string)p.Element("AcademicHouse"),
                    EmailAddress = (string)p.Element("EmailAddress"),
                    Form = (string)p.Element("Form"),
                    FamilyId = (string)p.Element("FamilyId"),
                }).ToList();
        }
        public List<Staff> GetStaff(XDocument xDoc)
        {
            return xDoc.Descendants("StaffMember")
                .Select(s => new Staff
                {
                    Id = (int)s.Attribute("Id"),
                    Forename = (string)s.Element("Forename"),
                    Surname = (string)s.Element("Surname"),
                    Title = (string)s.Element("Title"),
                    EmailAddress = (string)s.Element("SchoolEmailAddress"),
                    Roles = s.Descendants("Role").Select(r => (string)r.Element("Name")).ToList()
                }).ToList();
        }
        public List<YearGroup> GetYears(XDocument xDoc)
        {
            return xDoc.Descendants("Year")
                .Select(y => new YearGroup
                {
                    Id = (int)y.Attribute("Id"),
                    Name = (string)y.Element("Name")
                }).ToList();
        }
        public SchoolData GetSchoolData()
        {
            var xDoc = LoadXmlAsync();

            var data = new SchoolData
            {
                Contacts = GetContacts(xDoc),
                Pupils = GetPupils(xDoc),
                StaffMembers = GetStaff(xDoc),
                YearGroups = GetYears(xDoc)
            };

            return data;
        }



        public void DownloadImages(string path, string extractPath)
        {
            string zipPath = Path.Combine(path, "photos.zip");
            string url =
                "https://kingsthecrown.isamshosting.cloud/api/batch/1.0/photos.ashx?apiKey=0E01C564-5AAE-4944-8B07-DAAC8A909F9F";
            using (var client = new HttpClient())
            {
                var fileBytes = client.GetByteArrayAsync(url).Result;
                File.WriteAllBytes(zipPath, fileBytes);
            }
            if (Directory.Exists(extractPath))
            {
                Directory.Delete(extractPath, true);
            }

            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }

    }
}

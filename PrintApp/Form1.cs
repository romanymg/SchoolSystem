using Common.Enums;
using Common.Models;
using PrintApp.Services;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace PrintApp
{
    public partial class Form1 : Form
    {
        private readonly AppServices appServices = new AppServices();
        string SaveFolderPath = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //lblStatus.Text = appServices.ApiUrl;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            if (fl.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            SaveFolderPath = fl.SelectedPath + "\\";

            new Thread(() => StartLogic()).Start();
        }

        void StartLogic()
        {
            int printed = rbNotPrinted.Checked ? 0 : -1;
            string code = txtCode.Text.Trim();

            int userType = rbStudent.Checked ? (int)UserTypeEnum.Student : (int)UserTypeEnum.Parent;

            this.BeginInvoke((MethodInvoker)delegate ()
            {
                lblStatus.Text = $"Loading data...";
            });

            try
            {
                var result = appServices.GetUsers(userType, printed, code).Result;

                if (!result.Any())
                {
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        lblStatus.Text = $"No Data";
                    });
                    return;
                }

                foreach (var row in result)
                {
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        lblStatus.Text = $"Processing: {row.FullName}";
                    });

                    if (userType == (int)UserTypeEnum.Student)
                        DrawStudent(row);
                    else
                        DrawParent(row);
                }

                this.BeginInvoke((MethodInvoker)delegate () { MessageBox.Show("Finished"); });
            }
            catch (Exception ex)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    lblStatus.Text = $"{ex.Message}";
                });
            }

        }

        void DrawStudent(UserEntity row)
        {
            try
            {
                string backgroundImageUrl = "BackImages/Student.png";

                SolidBrush brush1 = new SolidBrush((Color)new ColorConverter().ConvertFromString("#091F13"));
                SolidBrush brush2 = new SolidBrush((Color)new ColorConverter().ConvertFromString("#063721"));

                string PersonCode = row.UserCode;
                string PersonName = row.FullName;
                var classTitle = row.Class;
                var imageUrl = $"{appServices.ApiUrl}{row.ImageUrl}";

                Image imgBk = Image.FromFile(backgroundImageUrl);
                imgBk = ResizeImage(imgBk, 1000, 628);
                HorizontalResolution = imgBk.HorizontalResolution;
                VerticalResolution = imgBk.VerticalResolution;

                Graphics objGrahpics = Graphics.FromImage(imgBk);

                objGrahpics.DrawImage(imgBk, 0, 0);

                if (string.IsNullOrEmpty(imageUrl))
                {
                    return;
                }

                Image imgPerson = LoadImageFromUrlAsync(imageUrl).Result;
                imgPerson = ResizeImage(imgPerson, 253, 310);
                objGrahpics.DrawImage(imgPerson, 700, 210);

                objGrahpics.DrawString($"STUDENT NAME: {PersonName}", new Font("Brown Regular", 8, FontStyle.Bold),
                    brush1, new RectangleF(50, 250, imgBk.Width, 0),
                    new StringFormat { Alignment = StringAlignment.Near, FormatFlags = StringFormatFlags.NoWrap });

                objGrahpics.DrawString($"STUDENT ID: {PersonCode}", new Font("Brown Regular", 8, FontStyle.Bold),
                    brush1, new RectangleF(50, 320, imgBk.Width, 0),
                    new StringFormat { Alignment = StringAlignment.Near });

                objGrahpics.DrawString($"CLASS: {classTitle}", new Font("Brown Regular", 8, FontStyle.Bold), brush1,
                    new RectangleF(50, 390, imgBk.Width, 0), new StringFormat { Alignment = StringAlignment.Near });

                imgBk = ResizeImage(imgBk, 600, 377);
                SaveImageToHardDisk(imgBk, $"{PersonCode}.jpg");
            }
            catch (Exception ex)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    lblStatus.Text = $"{ex.Message}";
                });
            }
        }

        void DrawParent(UserEntity row)
        {
            try
            {
                string backgroundImageUrl = "BackImages/Parent.png";

                SolidBrush brush1 = new SolidBrush((Color)new ColorConverter().ConvertFromString("#091F13"));
                SolidBrush brush2 = new SolidBrush((Color)new ColorConverter().ConvertFromString("#063721"));

                string PersonName = row.FullName;
                var PersonCode = row.ReferenceId;
                var imageUrl = $"{appServices.ApiUrl}{row.ImageUrl}";
                //var students = dtData.AsEnumerable().Where(row => row["ParentLoginCode"].ToString() == PersonCode).CopyToDataTable();

                if (string.IsNullOrEmpty(imageUrl))
                {
                    return;
                }

                Image imgBk = Image.FromFile(backgroundImageUrl);
                imgBk = ResizeImage(imgBk, 1000, 628);
                HorizontalResolution = imgBk.HorizontalResolution;
                VerticalResolution = imgBk.VerticalResolution;

                Graphics objGrahpics = Graphics.FromImage(imgBk);
                objGrahpics.DrawImage(imgBk, 0, 0);

                try
                {
                    Image imgPerson = LoadImageFromUrlAsync(imageUrl).Result;
                    imgPerson = ResizeImage(imgPerson, 253, 310);
                    objGrahpics.DrawImage(imgPerson, 700, 210);
                }
                catch (Exception)
                {
                    return;
                }

                objGrahpics.DrawString($"PARENT NAME: {PersonName}", new Font("Brown Regular", 8, FontStyle.Bold),
                    brush1, new RectangleF(50, 250, imgBk.Width, 0),
                    new StringFormat { Alignment = StringAlignment.Near, FormatFlags = StringFormatFlags.NoWrap });

                //if (students != null)
                //{
                //    objGrahpics.DrawString($"STUDENT NAME:", new Font("Brown Regular", 8, FontStyle.Bold), brush1, new RectangleF(50, 320, imgBk.Width, 0), new StringFormat { Alignment = StringAlignment.Near });

                //    for (int i = 0; i < students.Rows.Count; i++)
                //    {
                //        var y = 320 + (50 * i);
                //        var stName = students.Rows[i]["StudentFirstName"].ToString();
                //        var stYear = students.Rows[i]["Year"].ToString();

                //        objGrahpics.DrawString($"{stName}", new Font("Brown Regular", 8, FontStyle.Bold), brush1, new RectangleF(350, y, 300, 0), new StringFormat { Alignment = StringAlignment.Near });
                //        objGrahpics.DrawString($"{stYear}", new Font("Brown Regular", 8, FontStyle.Bold), brush1, new RectangleF(600, y, 300, 0), new StringFormat { Alignment = StringAlignment.Near });
                //    }
                //}
                imgBk = ResizeImage(imgBk, 600, 377);
                SaveImageToHardDisk(imgBk, $"{PersonCode}.jpg");
            }
            catch (Exception ex)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    lblStatus.Text = $"{ex.Message}";
                });
            }
        }

        float VerticalResolution = 0, HorizontalResolution = 0;
        public Bitmap ResizeImage(Image image, int width, int height)
        {
            const int orientationId = 0x0112; // Property tag for orientation
            if (image.PropertyIdList.Contains(orientationId))
            {
                var prop = image.GetPropertyItem(orientationId);
                int orientationValue = BitConverter.ToUInt16(prop.Value, 0);

                switch (orientationValue)
                {
                    case 3: // 180 degrees
                        image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 6: // 90 degrees clockwise
                        image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 8: // 90 degrees counter-clockwise
                        image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                }

                image.RemovePropertyItem(orientationId);
            }

            Bitmap result = new Bitmap(width, height);

            result.SetResolution(HorizontalResolution > 0 ? HorizontalResolution : 300,
                HorizontalResolution > 0 ? HorizontalResolution : 300);
            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.TextContrast = 0;
                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                graphics.DrawImage(image, 0, 0, result.Width, result.Height);
            }

            return result;
        }
        void SaveImageToHardDisk(Image imgBk, string fileName)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                pictureBox1.Image = imgBk;
                if (!Directory.Exists(SaveFolderPath))
                {
                    Directory.CreateDirectory(SaveFolderPath);
                }

                ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                myEncoderParameters.Param[0] = new EncoderParameter(myEncoder, 100L);
                imgBk.Save((SaveFolderPath + "/" + fileName), jgpEncoder, myEncoderParameters);
            });
        }
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }

            return null;
        }
        private async Task<Image> LoadImageFromUrlAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                using (var ms = new MemoryStream(await response.Content.ReadAsByteArrayAsync()))
                {
                    return Image.FromStream(ms);
                }
            }
        }

    }
}
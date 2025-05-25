namespace cv_tax.Models {
    public class CVModel(string profile, string[] projects, string[] education, string[] courses) {

        public string Profile { get; set; } = profile;
        public string[] Projects { get; } = projects;
        public string[] Education { get; } = education;
        public string[] Courses { get; } = courses;
    }
}

namespace cv_tax.Models {
    public class PictureModel {

        public int Id { get; set; }
        public string FilePath { get; set; }

        public PictureModel(string filePath) {
            FilePath = filePath;
        }
    }
}

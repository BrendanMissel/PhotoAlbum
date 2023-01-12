namespace PhotoAlbum.App
{
    public class PhotoAlbumService
    {
        private const string BAD_INPUT_RESPONSE = "Input invalid: Please enter a numeric album id.";
        public IEnumerable<string> GetPhotosByAlbumId(string? userInput)
        {
            List<string> photos = new();
            int id = -1;

            bool isEmpty = userInput == null || userInput == string.Empty;
            bool isNumeric = int.TryParse(userInput, out id);

            // Here, I'm assuming the index starts at 1 (rather than 0) as the full dataset shows
            if (isEmpty || (isNumeric && id <= 0) || !isNumeric) 
            {
                photos.Add(BAD_INPUT_RESPONSE);
                return photos;

            }

            return photos;
        }
    }
}
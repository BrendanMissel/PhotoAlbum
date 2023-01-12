namespace PhotoAlbum.App
{
    public class PhotoAlbumService
    {
        private const string BAD_INPUT_RESPONSE = "Input invalid: Please enter a numeric album id.";
        public IEnumerable<string> GetPhotosByAlbumId(string? userInput)
        {
            List<string> photos = new();
            
            photos = ScrubUserInput(ref userInput);

            if (photos.Count > 0)
            {
                return photos;
            }


            return photos;
        }

        /// <summary>
        /// Given raw user input, ensure it is not null, empty, and a positive integer value. 
        /// </summary>
        /// <param name="userInput">Raw user input from the command line.</param>
        /// <returns>If bad input is detected an error message will be returned to the caller.</returns>
        private static List<string> ScrubUserInput(ref string? userInput)
        {
            List<string> errorMessages = new();

            bool isEmpty = userInput == null || userInput == string.Empty;
            bool isNumeric = int.TryParse(userInput, out int id);

            // Here, I'm assuming the index starts at 1 (rather than 0) as the full dataset shows
            if (isEmpty || (isNumeric && id <= 0) || !isNumeric) 
            {
                errorMessages.Add(BAD_INPUT_RESPONSE);
                return errorMessages;
            }

            userInput = id.ToString();
            return errorMessages;
        }
    }
}
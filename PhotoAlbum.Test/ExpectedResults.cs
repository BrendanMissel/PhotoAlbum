namespace PhotoAlbum.Test
{
    internal static class ExpectedResults
    {
        public static IEnumerable<string> EXPECTED_BAD_INPUT_RESPONSE = new List<string>(){ "Input invalid: Please enter a numeric album id." };
        public static string EXPECTED_OUTPUT_PHOTO_ID_1 = "[1] accusamus beatae ad facilis cum similique qui sunt";
        public static IEnumerable<string> EXPECTED_NO_OUTPUTS_RESPONSE = new List<string>() { "No photos found with given album id:" };
    }
}

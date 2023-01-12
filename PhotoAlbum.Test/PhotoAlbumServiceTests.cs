using static PhotoAlbum.Test.ExpectedResults;

namespace PhotoAlbum.Test;

public class PhotoAlbumServiceTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void GetPhotosByAlbumId_HandlesBadInput(string? input)
    {
        PhotoAlbumService albumService = new();

        IEnumerable<string> actual = albumService.GetPhotosByAlbumId(input);

        Assert.Equivalent(EXPECTED_BAD_INPUT_RESPONSE, actual);
    }
}
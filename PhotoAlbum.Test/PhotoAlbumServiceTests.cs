using PhotoAlbum.App;
using static PhotoAlbum.Test.ExpectedResults;

namespace PhotoAlbum.Test;

public class PhotoAlbumServiceTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("A")]
    [InlineData("j")]
    [InlineData("@")]
    [InlineData("A1")]
    [InlineData("-9")]
    [InlineData("0")]
    public void GetPhotosByAlbumId_HandlesBadInput(string? input)
    {
        PhotoAlbumService albumService = new();

        IEnumerable<string> actual = albumService.GetPhotosByAlbumId(input);

        Assert.Equivalent(EXPECTED_BAD_INPUT_RESPONSE, actual);
    }
}
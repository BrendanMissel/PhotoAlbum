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

    [Fact]
    public void GetPhotosByAlbumId_ReturnsInCorrectFormat()
    {
        PhotoAlbumService albumService = new();
    
        IEnumerable<string> photos = albumService.GetPhotosByAlbumId("1");
        string? actual = photos.FirstOrDefault();

        Assert.Equal(EXPECTED_OUTPUT_PHOTO_ID_1, actual);
    }

    [Theory]
    [InlineData("100000")]
    [InlineData("234567")]
    public void GetPhotosByAlbumId_HandlesNoResults(string? input)
    {
        PhotoAlbumService albumService = new();
        List<string> expected = new() { EXPECTED_NO_OUTPUTS_RESPONSE + " " + input };

        IEnumerable<string> actual = albumService.GetPhotosByAlbumId(input);

        Assert.Equivalent(expected, actual);
    }
}
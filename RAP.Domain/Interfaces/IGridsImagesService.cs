namespace RAP.Domain.Interfaces
{
    public interface IGridsImagesService
    {
        string GetPathToDirectory(string keyAppSettings);

        bool IsGetAndValidExtencion(ref string nameFile, string inputPath);
    }
}

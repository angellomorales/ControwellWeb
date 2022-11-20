namespace ControWell.Client.Services.PozoService
{
    public interface IPozoService
    {
        List<Pozo> Pozos { get; set; }
        Task GetPozos();
        Task<Pozo> GetSinglePozo(int id);
        Task<Pozo> GetPozo();

        Task<Pozo> CreatePozo(Pozo pozo);
        Task<Pozo> UpdatePozo(Pozo pozo);
        Task<Pozo> DeletePozo(int id);

    }
}

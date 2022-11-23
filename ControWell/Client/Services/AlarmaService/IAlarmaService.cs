namespace ControWell.Client.Services.AlarmaService
{
    public interface IAlarmaService
    {
        List<Alarma> Alarmas { get; set; }
        List<VariableProceso> VariableProcesos { get; set; }
        List<Pozo> Pozos { get; set; }

    }
}

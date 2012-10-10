namespace ZplLabels.configs
{
    using StructureMap.Configuration.DSL;

    public class ZplPrintRegistry : Registry
    {
        public ZplPrintRegistry()
        {
            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.WithDefaultConventions();
                     });
        }
    }
}
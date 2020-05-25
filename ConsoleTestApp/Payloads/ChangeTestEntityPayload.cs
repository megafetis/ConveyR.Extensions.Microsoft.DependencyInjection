namespace ConsoleTestApp.Payloads
{
    public class ChangeTestEntityPayload:IHasNamePayload,IHasDescriptionPayload
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

namespace Plivo.Resource
{
    public class NestedResponse
    {
        public Meta Meta { get; set; }

        public object Objects { get; set; }

        public override string ToString()
        {
            return
                "[Meta]\n" + Meta + "\n" +
                "[Objects]\n" + string.Join("\n", Objects);
        }
    }
}
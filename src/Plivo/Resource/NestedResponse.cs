namespace Plivo.Resource
{
    public class NestedResponse
    {
        public Meta Meta { get; set; }

        public object Objects { get; set; }

        public override string ToString()
        {
            return
                "[Objects]\n" + string.Join("\n", Objects);
        }
    }
}
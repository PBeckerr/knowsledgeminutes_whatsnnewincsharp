using System.Threading.Tasks;

namespace KnowledgeMinutes
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            await Task.Delay(400);
            CSharp70.RefReturnAndLocalFunction();
        }
    }
}
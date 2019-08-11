using Ninject;
using SevenWest.Services;

namespace SevenWest
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new IoC());

            var processor = kernel.Get<IProcessor>();
            processor.Process();
        }
    }
}

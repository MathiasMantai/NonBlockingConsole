using System.Collections.Concurrent;

namespace NFC_Recker_Eventbased.NonBlockingConsole
{
    /// <summary>
    /// Class <c>NonBlockingConsole</c> creates a queue for writing to console
    /// implements a version of the producer consumer pattern
    /// </summary>
    static class NonBlockingConsole
    {
        private static BlockingCollection<string> queue = new BlockingCollection<string>();
        
        /// <summary>
        /// Method <c>NonBlockingConsole</c> The constructor creates a separate thread, where strings are written to the console
        /// </summary>
        static NonBlockingConsole() {
            var thread = new Thread(() => {
                  while(true)
                  {
                        Console.WriteLine(queue.Take());
                  }
            });
            thread.IsBackground = true;
            thread.Start();
        } 
        
        /// <summary>
        /// Method <c>WriteLine</c> adds strings to the queue. Will be used instead of the conventional WriteLine
        /// </summary>
        /// <param name="Message">string to be added to the queue</param>
        public static void WriteLine(string Message)
        {
            queue.Add(Message); 
        }
    }
}
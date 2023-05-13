using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace DemoKatalon.Utils
{
    public class ExtentManager
    {
        public ExtentReports extent = null;
        ExtentTest test = null;
        public ExtentManager()
        {
            extent = new ExtentReports();
            var htmlreprter = new ExtentHtmlReporter(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"../../../ExtentReports/index.html")));
            extent.AttachReporter(htmlreprter);
        }
        public void StartTest(string testname)
        {
            test = extent.CreateTest(testname).Info(testname + " test started");
        }
        public void Info(string info)
        {
            test.Info(info);
        }
        public void TestPass(string info)
        {
            test.Pass(info);
        }
        public void TestFail(string info)
        {
            test.Fail(info);
        }
        public void ExtentEnd()
        {
            extent.Flush();
        }
    }
}

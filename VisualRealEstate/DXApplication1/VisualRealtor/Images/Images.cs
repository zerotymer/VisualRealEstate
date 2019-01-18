using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VisualRealtor
{
    public static class Images
    {
        static ImageSource GetImage(string path)
        {
            return new BitmapImage(new Uri(path, UriKind.Relative));
        }

        private const String MaterialPath = "/images/material/";

        public static ImageSource About { get { return GetImage(ImagePaths.About); } }
        public static ImageSource CloseSolution { get { return GetImage(ImagePaths.CloseSolution); } }
        public static ImageSource Copy { get { return GetImage(ImagePaths.Copy); } }
        public static ImageSource Cut { get { return GetImage(ImagePaths.Cut); } }
        public static ImageSource DevExpressLogo { get { return GetImage(ImagePaths.DevExpressLogo); } }
        public static ImageSource Error { get { return GetImage(ImagePaths.Error); } }
        public static ImageSource File { get { return GetImage(ImagePaths.File); } }
        public static ImageSource FileCS { get { return GetImage(ImagePaths.FileCS); } }
        public static ImageSource FileXaml { get { return GetImage(ImagePaths.FileXaml); } }
        public static ImageSource Find { get { return GetImage(ImagePaths.Find); } }
        public static ImageSource FindInFiles { get { return GetImage(ImagePaths.FindInFiles); } }
        public static ImageSource FindInFilesWindow { get { return GetImage(ImagePaths.FindInFilesWindow); } }
        public static ImageSource Info { get { return GetImage(ImagePaths.Info); } }
        public static ImageSource LoadLayout { get { return GetImage(ImagePaths.LoadLayout); } }
        public static ImageSource NewProject { get { return GetImage(ImagePaths.NewProject); } }
        public static ImageSource Notification { get { return GetImage(ImagePaths.Notification); } }
        public static ImageSource OpenFile { get { return GetImage(ImagePaths.OpenFile); } }
        public static ImageSource OpenSolution { get { return GetImage(ImagePaths.OpenSolution); } }
        public static ImageSource Output { get { return GetImage(ImagePaths.Output); } }
        public static ImageSource Paste { get { return GetImage(ImagePaths.Paste); } }
        public static ImageSource PropertiesWindow { get { return GetImage(ImagePaths.PropertiesWindow); } }
        public static ImageSource Redo { get { return GetImage(ImagePaths.Redo); } }
        public static ImageSource References { get { return GetImage(ImagePaths.References); } }
        public static ImageSource Refresh { get { return GetImage(ImagePaths.Refresh); } }
        public static ImageSource Replace { get { return GetImage(ImagePaths.Replace); } }
        public static ImageSource Run { get { return GetImage(ImagePaths.Run); } }
        public static ImageSource Save { get { return GetImage(ImagePaths.Save); } }
        public static ImageSource SaveAll { get { return GetImage(ImagePaths.SaveAll); } }
        public static ImageSource SaveLayout { get { return GetImage(ImagePaths.SaveLayout); } }
        public static ImageSource ShowAllFiles { get { return GetImage(ImagePaths.ShowAllFiles); } }
        public static ImageSource SolutionExplorer { get { return GetImage(ImagePaths.SolutionExplorer); } }
        public static ImageSource TaskList { get { return GetImage(ImagePaths.TaskList); } }
        public static ImageSource Toolbox { get { return GetImage(ImagePaths.Toolbox); } }
        public static ImageSource Undo { get { return GetImage(ImagePaths.Undo); } }
        public static ImageSource Warning { get { return GetImage(ImagePaths.Warning); } }

        public static ImageSource Option { get { return GetImage(MaterialPath + "ic_settings_black_18dp.png"); } }
        public static ImageSource Copyright { get { return GetImage(MaterialPath + "ic_copyright_black_18dp.png"); } }
        public static ImageSource Government_16 { get => GetImage(ImagePaths.Government_16); }
        public static ImageSource Government_32 { get => GetImage(ImagePaths.Government_32); }

    }

    public static class ImagePaths
    {
        const string folder = "/Images/Docking/";

        public const string About = folder + "About.png";
        public const string CloseSolution = folder + "CloseSolution.png";
        public const string Copy = folder + "Copy.png";
        public const string Cut = folder + "Cut.png";
        public const string DevExpressLogo = folder + "DevExpressLogo.png";
        public const string Error = folder + "Error.png";
        public const string File = folder + "File.png";
        public const string FileCS = folder + "FileCS.png";
        public const string FileXaml = folder + "FileXaml.png";
        public const string Find = folder + "Find.png";
        public const string FindInFiles = folder + "FindInFiles.png";
        public const string FindInFilesWindow = folder + "FindInFilesWindow.png";
        public const string Info = folder + "Info.png";
        public const string LoadLayout = folder + "LoadLayout.png";
        public const string NewProject = folder + "NewProject.png";
        public const string Notification = folder + "Notification.png";
        public const string OpenFile = folder + "OpenFile.png";
        public const string OpenSolution = folder + "OpenSolution.png";
        public const string Output = folder + "Output.png";
        public const string Paste = folder + "Paste.png";
        public const string PropertiesWindow = folder + "PropertiesWindow.png";
        public const string Redo = folder + "Redo.png";
        public const string References = folder + "References.png";
        public const string Refresh = folder + "Refresh.png";
        public const string Replace = folder + "Replace.png";
        public const string Run = folder + "Run.png";
        public const string Save = folder + "Save.png";
        public const string SaveAll = folder + "SaveAll.png";
        public const string SaveLayout = folder + "SaveLayout.png";
        public const string ShowAllFiles = folder + "ShowAllFiles.png";
        public const string SolutionExplorer = folder + "SolutionExplorer.png";
        public const string TaskList = folder + "TaskList.png";
        public const string Toolbox = folder + "Toolbox.png";
        public const string Undo = folder + "Undo.png";
        public const string Warning = folder + "Warning.png";

        public const string Option = folder + "Option.png";
        public const String Government_16 = "/Images/government_16.png";
        public const String Government_32 = "/Images/government_32.png";
    }
}

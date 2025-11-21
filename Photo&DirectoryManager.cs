using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FinalEDPOrderingSystem
{
    public static class Photo_DirectoryManager
    {
        private static readonly string ProjectRoot =
            Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;

        private static readonly string BasePhotoDir =
            Path.Combine(ProjectRoot, "SystemAssets", "Images");

        // -------------------------
        // Helpers
        // -------------------------
        private static void EnsureDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private static string MakeRelative(string fullPath)
        {
            var root = ProjectRoot.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
            return fullPath.Replace(root, "").Replace('/', '\\');
        }

        public static string SaveImage(string selectedFile, string folderName)
        {
            string directory = Path.Combine(BasePhotoDir, folderName);
            EnsureDirectory(directory);

            string fileName = Guid.NewGuid() + Path.GetExtension(selectedFile);
            string destPath = Path.Combine(directory, fileName);

            File.Copy(selectedFile, destPath, true);

            return MakeRelative(destPath);
        }

        public static Image LoadImage(string relativePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(relativePath))
                    return null;

                string fullPath = Path.Combine(ProjectRoot, relativePath);

                if (!File.Exists(fullPath))
                    return null;

                using (var img = Image.FromFile(fullPath))
                    return new Bitmap(img);
            }
            catch
            {
                return null;  // always fail gracefully
            }
        }



        // -------------------------
        // Employee image 
        // -------------------------
        public static string SaveEmployeeImage(string selectedFile)
        {
            string folder = Path.Combine(BasePhotoDir, "Employees");
            EnsureDirectory(folder);

            string fileName = Guid.NewGuid() + Path.GetExtension(selectedFile);
            string destPath = Path.Combine(folder, fileName);

            File.Copy(selectedFile, destPath, true);

            return MakeRelative(destPath);
        }

        // -------------------------
        // Product (single main image) - Individual product
        // -------------------------
        public static string SaveProductImage(string selectedFile, int productID)
        {
            // folder: SystemAssets/Images/Products/Individual/Product_<productID>/
            string folder = Path.Combine(BasePhotoDir, "Products", "Individual", $"Product_{productID}");
            EnsureDirectory(folder);

            // delete any existing "main.*" to ensure single-image behavior
            foreach (var f in Directory.GetFiles(folder).Where(f => Path.GetFileName(f).StartsWith("main.", StringComparison.OrdinalIgnoreCase)))
            {
                try { File.Delete(f); } catch { /* best effort */ }
            }

            string ext = Path.GetExtension(selectedFile);
            string fileName = "main" + ext;
            string destPath = Path.Combine(folder, fileName);

            File.Copy(selectedFile, destPath, true);

            return MakeRelative(destPath);
        }

        // -------------------------
        // Bundle (single main image)
        // -------------------------
        public static string SaveBundleImage(string selectedFile, int bundleID)
        {
            // folder: SystemAssets/Images/Products/Bundled/Bundle_<bundleID>/
            string folder = Path.Combine(BasePhotoDir, "Products", "Bundled", $"Bundle_{bundleID}");
            EnsureDirectory(folder);

            // delete existing main.* files
            foreach (var f in Directory.GetFiles(folder).Where(f => Path.GetFileName(f).StartsWith("main.", StringComparison.OrdinalIgnoreCase)))
            {
                try { File.Delete(f); } catch { }
            }

            string ext = Path.GetExtension(selectedFile);
            string fileName = "main" + ext;
            string destPath = Path.Combine(folder, fileName);

            File.Copy(selectedFile, destPath, true);

            return MakeRelative(destPath);
        }
        public static void DeleteProductFolder(int productId)
        {
            string folder = Path.Combine(
                BasePhotoDir,
                "Products",
                "Individual",
                $"Product_{productId}"
            );

            if (Directory.Exists(folder))
            {
                try
                {
                    Directory.Delete(folder, true);  // delete folder + all images
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete product image folder:\n{ex.Message}",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

    }
}

using System.Diagnostics;
using Utils;
using Visualize3D.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Visualize3D {
	class ProgramData {
		public static Visualize3DModel? Instance { get; set; }
		public static string CONFIG = AssemblyDirectory + "\\config.xml";
		public static string FILTER = "XML File | *.xml";
		public static bool ValidConfigLocation = false;
		public static bool ShouldBeValidConfigLocation = false;
		public static bool Changed = false;
		public static bool InvalidFile = false;

		public static string AssemblyDirectory {
			get {
				return Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName ?? string.Empty) ?? string.Empty;
			}
		}
		public static void LoadConfig() {
			Instance = XMLUtils.LoadFromFile<Visualize3DModel>(ProgramData.CONFIG);
			if (Instance != null && ShouldBeValidConfigLocation) {
				ValidConfigLocation = true;
			}
		}
		public static bool OpenConfig() {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = FILTER;
			ofd.InitialDirectory = AssemblyDirectory;
			InvalidFile = false;
			if (ofd.ShowDialog() == DialogResult.OK) {
				CONFIG = ofd.FileName;
				LoadConfig();
				if (Instance != null) {
					ValidConfigLocation = true;
					return true;
				}
				InvalidFile = true;
			}
			ofd.Dispose();
			return false;
		}
		public static bool SaveConfig() {
			if (ProgramData.Instance == null) return false;
			if (!ValidConfigLocation) {
				return SaveConfigAs();
			} else {
				Instance.SaveToFile(CONFIG);
				Changed = false;
				return true;
			}
		}
		public static bool SaveConfigAs() {
			if (ProgramData.Instance == null) return false;
			SaveFileDialog d = new SaveFileDialog();
			d.Filter = FILTER;
			d.InitialDirectory = AssemblyDirectory;
			if (d.ShowDialog() == DialogResult.OK) {
				Instance.SaveToFile(d.FileName);
				CONFIG = d.FileName;
				ValidConfigLocation = true;
				Changed = false;
				return true;
			}
			d.Dispose();
			return false;
		}
	}
}

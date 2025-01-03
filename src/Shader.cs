using OpenTK.Graphics.OpenGL4;

namespace Umbrella {
	public class Shader {
		private Int32 handle;

		public Int32 Handle {
			get {
				return handle;
			}
		}

		public Shader(string vertexPath, string fragmentPath) {
			string vertexShaderSource = File.ReadAllText(vertexPath);
			string fragmentShaderSource = File.ReadAllText(fragmentPath);

			Int32 vertexShader = GL.CreateShader(ShaderType.VertexShader);
			GL.ShaderSource(vertexShader, vertexShaderSource);

			Int32 fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
			GL.ShaderSource(fragmentShader, fragmentShaderSource);
			
			Int32 success;
			GL.CompileShader(vertexShader);
			GL.GetShader(vertexShader, ShaderParameter.CompileStatus, out success);
			if (success == 0) {
				string infoLog = GL.GetShaderInfoLog(vertexShader);
				Console.WriteLine(infoLog);
			}
						
			GL.CompileShader(fragmentShader);
			GL.GetShader(fragmentShader, ShaderParameter.CompileStatus, out success);
			if (success == 0) {
				string infoLog = GL.GetShaderInfoLog(fragmentShader);
				Console.WriteLine(infoLog);
			}

			handle = GL.CreateProgram();

			GL.AttachShader(handle, vertexShader);
			GL.AttachShader(handle, fragmentShader);

			GL.LinkProgram(handle);

			GL.GetProgram(handle, GetProgramParameterName.LinkStatus, out success);
			if (success == 0) {
				string infoLog = GL.GetProgramInfoLog(handle);
				Console.WriteLine(infoLog);
			}
		}
	}
}

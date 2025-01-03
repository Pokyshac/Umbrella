using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Umbrella {
    public class Window : GameWindow {
		public Int32 VBO;
		private Float32[] vertices = {
		    -0.5f, -0.5f, 0.0f, //Bottom-left vertex
		     0.5f, -0.5f, 0.0f, //Bottom-right vertex
		     0.0f,  0.5f, 0.0f  //Top vertex
		};
		
		public Window(Int32 width, Int32 height, string title) : base(GameWindowSettings.Default, 
			new NativeWindowSettings() { ClientSize = (width, height), Title = title }) {}

		protected override void OnUpdateFrame(FrameEventArgs args) {
			base.OnUpdateFrame(args);

			if (KeyboardState.IsKeyDown(Keys.Escape)) {
				Close();
			}
		}

		protected override void OnLoad() {
			base.OnLoad();

			GL.ClearColor(0.2f, 0.0f, 0.3f, 1.0f);

			VBO = GL.GenBuffer();
			GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
			GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(Float32), vertices, BufferUsageHint.StaticDraw);
		}

		protected override void OnRenderFrame(FrameEventArgs args) {
			base.OnRenderFrame(args);

			GL.Clear(ClearBufferMask.ColorBufferBit);

			SwapBuffers();
		}

		protected override void OnFramebufferResize(FramebufferResizeEventArgs args) {
			base.OnFramebufferResize(args);

			GL.Viewport(0, 0, args.Width, args.Height);
		}
    }
}

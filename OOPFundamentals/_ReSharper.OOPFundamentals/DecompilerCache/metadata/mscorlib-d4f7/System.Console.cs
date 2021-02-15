// Type: System.Console
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.IO;
using System.Security;
using System.Text;

namespace System
{
    public static class Console
    {
        public static TextWriter Error { [SecuritySafeCritical]
        get; }

        public static TextReader In { [SecuritySafeCritical]
        get; }

        public static TextWriter Out { [SecuritySafeCritical]
        get; }

        public static Encoding InputEncoding { [SecuritySafeCritical]
        get; [SecuritySafeCritical]
        set; }

        public static Encoding OutputEncoding { [SecuritySafeCritical]
        get; [SecuritySafeCritical]
        set; }

        public static ConsoleColor BackgroundColor { [SecuritySafeCritical]
        get; [SecuritySafeCritical]
        set; }

        public static ConsoleColor ForegroundColor { [SecuritySafeCritical]
        get; [SecuritySafeCritical]
        set; }

        public static int BufferHeight { [SecuritySafeCritical]
        get; [SecuritySafeCritical]
        set; }

        public static int BufferWidth { [SecuritySafeCritical]
        get; [SecuritySafeCritical]
        set; }

        public static int WindowHeight { [SecuritySafeCritical]
        get; [SecuritySafeCritical]
        set; }

        public static int WindowWidth { [SecuritySafeCritical]
        get; [SecuritySafeCritical]
        set; }

        public static int LargestWindowWidth { [SecuritySafeCritical]
        get; }

        public static int LargestWindowHeight { [SecuritySafeCritical]
        get; }

        public static int WindowLeft { [SecuritySafeCritical]
        get; [SecuritySafeCritical]
        set; }

        public static int WindowTop { [SecuritySafeCritical]
        get; [SecuritySafeCritical]
        set; }

        public static int CursorLeft { [SecuritySafeCritical]
        get; [SecuritySafeCritical]
        set; }

        public static int CursorTop { [SecuritySafeCritical]
        get; [SecuritySafeCritical]
        set; }

        public static int CursorSize { [SecuritySafeCritical]
        get; [SecuritySafeCritical]
        set; }

        public static bool CursorVisible { [SecuritySafeCritical]
        get; [SecuritySafeCritical]
        set; }

        public static string Title { [SecuritySafeCritical]
        get; [SecuritySafeCritical]
        set; }

        public static bool KeyAvailable { [SecuritySafeCritical]
        get; }

        public static bool NumberLock { [SecuritySafeCritical]
        get; }

        public static bool CapsLock { [SecuritySafeCritical]
        get; }

        public static bool TreatControlCAsInput { [SecuritySafeCritical]
        get; [SecuritySafeCritical]
        set; }

        public static void Beep();

        [SecuritySafeCritical]
        public static void Beep(int frequency, int duration);

        [SecuritySafeCritical]
        public static void Clear();

        [SecuritySafeCritical]
        public static void ResetColor();

        [SecuritySafeCritical]
        public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight,
                                          int targetLeft, int targetTop);

        [SecuritySafeCritical]
        public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight,
                                          int targetLeft, int targetTop, char sourceChar, ConsoleColor sourceForeColor,
                                          ConsoleColor sourceBackColor);

        [SecuritySafeCritical]
        public static void SetBufferSize(int width, int height);

        [SecuritySafeCritical]
        public static void SetWindowSize(int width, int height);

        [SecuritySafeCritical]
        public static void SetWindowPosition(int left, int top);

        [SecuritySafeCritical]
        public static void SetCursorPosition(int left, int top);

        public static ConsoleKeyInfo ReadKey();

        [SecuritySafeCritical]
        public static ConsoleKeyInfo ReadKey(bool intercept);

        public static Stream OpenStandardError();
        public static Stream OpenStandardError(int bufferSize);
        public static Stream OpenStandardInput();
        public static Stream OpenStandardInput(int bufferSize);
        public static Stream OpenStandardOutput();
        public static Stream OpenStandardOutput(int bufferSize);

        [SecuritySafeCritical]
        public static void SetIn(TextReader newIn);

        [SecuritySafeCritical]
        public static void SetOut(TextWriter newOut);

        [SecuritySafeCritical]
        public static void SetError(TextWriter newError);

        public static int Read();
        public static string ReadLine();
        public static void WriteLine();
        public static void WriteLine(bool value);
        public static void WriteLine(char value);
        public static void WriteLine(char[] buffer);
        public static void WriteLine(char[] buffer, int index, int count);
        public static void WriteLine(decimal value);
        public static void WriteLine(double value);
        public static void WriteLine(float value);
        public static void WriteLine(int value);

        [CLSCompliant(false)]
        public static void WriteLine(uint value);

        public static void WriteLine(long value);

        [CLSCompliant(false)]
        public static void WriteLine(ulong value);

        public static void WriteLine(object value);
        public static void WriteLine(string value);
        public static void WriteLine(string format, object arg0);
        public static void WriteLine(string format, object arg0, object arg1);
        public static void WriteLine(string format, object arg0, object arg1, object arg2);

        [CLSCompliant(false)]
        [SecuritySafeCritical]
        public static void WriteLine(string format, object arg0, object arg1, object arg2, object arg3);

        public static void WriteLine(string format, params object[] arg);
        public static void Write(string format, object arg0);
        public static void Write(string format, object arg0, object arg1);
        public static void Write(string format, object arg0, object arg1, object arg2);

        [SecuritySafeCritical]
        [CLSCompliant(false)]
        public static void Write(string format, object arg0, object arg1, object arg2, object arg3);

        public static void Write(string format, params object[] arg);
        public static void Write(bool value);
        public static void Write(char value);
        public static void Write(char[] buffer);
        public static void Write(char[] buffer, int index, int count);
        public static void Write(double value);
        public static void Write(decimal value);
        public static void Write(float value);
        public static void Write(int value);

        [CLSCompliant(false)]
        public static void Write(uint value);

        public static void Write(long value);

        [CLSCompliant(false)]
        public static void Write(ulong value);

        public static void Write(object value);
        public static void Write(string value);

        public static event ConsoleCancelEventHandler CancelKeyPress;
    }
}

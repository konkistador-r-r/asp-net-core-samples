// Type: System.GC
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace System
{
    public static class GC
    {
        public static int MaxGeneration { [SecuritySafeCritical]
        get; }

        [SecurityCritical]
        public static void AddMemoryPressure(long bytesAllocated);

        [SecurityCritical]
        public static void RemoveMemoryPressure(long bytesAllocated);

        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static int GetGeneration(object obj);

        public static void Collect(int generation);

        [SecuritySafeCritical]
        public static void Collect();

        [SecuritySafeCritical]
        public static void Collect(int generation, GCCollectionMode mode);

        [SecuritySafeCritical]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static int CollectionCount(int generation);

        [SecuritySafeCritical]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static void KeepAlive(object obj);

        [SecuritySafeCritical]
        public static int GetGeneration(WeakReference wo);

        [SecuritySafeCritical]
        public static void WaitForPendingFinalizers();

        [SecuritySafeCritical]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public static void SuppressFinalize(object obj);

        [SecuritySafeCritical]
        public static void ReRegisterForFinalize(object obj);

        [SecuritySafeCritical]
        public static long GetTotalMemory(bool forceFullCollection);

        [SecurityCritical]
        public static void RegisterForFullGCNotification(int maxGenerationThreshold, int largeObjectHeapThreshold);

        [SecurityCritical]
        public static void CancelFullGCNotification();

        [SecurityCritical]
        public static GCNotificationStatus WaitForFullGCApproach();

        [SecurityCritical]
        public static GCNotificationStatus WaitForFullGCApproach(int millisecondsTimeout);

        [SecurityCritical]
        public static GCNotificationStatus WaitForFullGCComplete();

        [SecurityCritical]
        public static GCNotificationStatus WaitForFullGCComplete(int millisecondsTimeout);
    }
}

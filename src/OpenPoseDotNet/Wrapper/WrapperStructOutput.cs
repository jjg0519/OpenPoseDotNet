﻿using System;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenPoseDotNet
{

    public sealed class WrapperStructOutput : OpenPoseObject
    {

        #region Constructors

        public WrapperStructOutput(double verbose = -1,
                                   string writeKeyPoint = "",
                                   DataFormat writeKeyPointFormat = DataFormat.Xml,
                                   string writeJson = "",
                                   string writeCocoJson = "",
                                   string writeCocoFootJson = "",
                                   int writeCocoJsonVariant = 1,
                                   string writeImages = "",
                                   string writeImagesFormat = "",
                                   string writeVideo = "",
                                   double writeVideoFps = -1d,
                                   string writeHeatMaps = "",
                                   string writeHeatMapsFormat = "",
                                   string writeVideoAdam = "",
                                   string writeBvh = "",
                                   string udpHost = "",
                                   string udpPort = "")
        {
            var writeKeyPointBytes = Encoding.UTF8.GetBytes(writeKeyPoint ?? "");
            var writeJsonBytes = Encoding.UTF8.GetBytes(writeJson ?? "");
            var writeCocoJsonBytes = Encoding.UTF8.GetBytes(writeCocoJson ?? "");
            var writeCocoFootJsonBytes = Encoding.UTF8.GetBytes(writeCocoFootJson ?? "");
            var writeImagesBytes = Encoding.UTF8.GetBytes(writeImages ?? "");
            var writeImagesFormatBytes = Encoding.UTF8.GetBytes(writeImagesFormat ?? "");
            var writeVideoBytes = Encoding.UTF8.GetBytes(writeVideo ?? "");
            var writeHeatMapsBytes = Encoding.UTF8.GetBytes(writeHeatMaps ?? "");
            var writeHeatMapsFormatBytes = Encoding.UTF8.GetBytes(writeHeatMapsFormat ?? "");
            var writeVideoAdamBytes = Encoding.UTF8.GetBytes(writeVideoAdam ?? "");
            var writeBvhBytes = Encoding.UTF8.GetBytes(writeBvh ?? "");
            var udpHostBytes = Encoding.UTF8.GetBytes(udpHost ?? "");
            var udpPortBytes = Encoding.UTF8.GetBytes(udpPort ?? "");

            this.NativePtr = Native.op_wrapperStructOutput_new(verbose,
                                                               writeKeyPointBytes,
                                                               writeKeyPointFormat,
                                                               writeJsonBytes,
                                                               writeCocoJsonBytes,
                                                               writeCocoFootJsonBytes,
                                                               writeCocoJsonVariant,
                                                               writeImagesBytes,
                                                               writeImagesFormatBytes,
                                                               writeVideoBytes,
                                                               writeVideoFps,
                                                               writeHeatMapsBytes,
                                                               writeHeatMapsFormatBytes,
                                                               writeVideoAdamBytes,
                                                               writeBvhBytes,
                                                               udpHostBytes,
                                                               udpPortBytes);
        }

        #endregion

        #region Methods

        #region Overrides

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            Native.op_wrapperStructOutput_delete(this.NativePtr);
        }

        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr op_wrapperStructOutput_new(double verbose,
                                                                   byte[] writeKeyPoint,
                                                                   DataFormat writeKeyPointFormat,
                                                                   byte[] writeJson,
                                                                   byte[] writeCocoJson,
                                                                   byte[] writeCocoFootJson,
                                                                   int writeCocoJsonVariant,
                                                                   byte[] writeImages,
                                                                   byte[] writeImagesFormat,
                                                                   byte[] writeVideo,
                                                                   double writeVideoFps,
                                                                   byte[] writeHeatMaps,
                                                                   byte[] writeHeatMapsFormat,
                                                                   byte[] writeVideoAdam,
                                                                   byte[] writeBvh,
                                                                   byte[] udpHost,
                                                                   byte[] udpPort);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void op_wrapperStructOutput_delete(IntPtr face);

        }

    }

}

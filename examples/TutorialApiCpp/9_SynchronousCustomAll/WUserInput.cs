﻿using System;
using System.IO;
using OpenPoseDotNet;
using UserDatum = OpenPoseDotNet.CustomDatum;

namespace SynchronousCustomAll
{

    // This worker will just read and return all the jpg files in a directory
    internal sealed class WUserInput : UserWorkerProducer<UserDatum>
    {

        #region Fields

        private readonly string[] _ImageFiles;

        private uint _Counter;

        #endregion

        #region Constructors

        public WUserInput(string directoryPath)
        {
            this._ImageFiles = Directory.GetFiles(directoryPath, "*.jpg");
            if (this._ImageFiles.Length == 0)
                OpenPose.Error("No images found on: " + directoryPath, -1, nameof(WUserInput));
        }

        #endregion

        #region Methods

        protected override void InitializationOnThread()
        {
        }

        protected override StdSharedPtr<StdVector<UserDatum>> WorkProducer()
        {
            try
            {
                // Close program when empty frame
                if (this._ImageFiles.Length <= this._Counter)
                {
                    OpenPose.Log("Last frame read and added to queue. Closing program after it is processed.", Priority.High);
                    // This funtion stops this worker, which will eventually stop the whole thread system once all the
                    // frames have been processed
                    this.Stop();
                    return null;
                }
                else
                {
                    // Create new datum
                    var tmp = new StdVector<UserDatum>();
                    tmp.EmplaceBack();
                    var datumsPtr = new StdSharedPtr<StdVector<UserDatum>>(tmp);
                    var datum = tmp.ToArray()[0];

                    // Fill datum
                    using (var mat = Cv.ImRead(this._ImageFiles[this._Counter++]))
                        datum.CvInputData = mat;

                    // If empty frame -> return nullptr
                    if (datum.CvInputData.Empty)
                    {
                        this.Stop();
                        datumsPtr = null;
                    }

                    return datumsPtr;
                }
            }
            catch (Exception e)
            {
                OpenPose.Log("Some kind of unexpected error happened.");
                this.Stop();
                OpenPose.Error(e.Message, -1, nameof(this.WorkProducer));
                return null;
            }
        }

        #endregion

    }

}
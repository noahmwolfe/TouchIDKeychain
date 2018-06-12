using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchIDKeychain
{
    public interface TouchIDAuthentication
    {
        bool IsHardwareDetected();
        bool IsDeviceSecured();
        bool IsFingerPrintEnrolled();
        bool IsPermissionGranted();
        void Authenticate(Action successAction = null, Action failAction = null);
        void CancelCurrentAuthentication();
        bool IsFingerprintAuthenticationPossible();
    }
}


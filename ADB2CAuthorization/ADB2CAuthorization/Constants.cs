namespace ADB2CAuthorization
{
	public static class Constants
	{
        // Tenant and Policies provided by Microsoft
        
        public static string ApplicationID = "90c0fe63-bcf2-44d5-8fb7-b8bbc0b29dc6";
        public static string SignUpSignInPolicy = "b2c_1_susi";
        public static string ResetPasswordPolicy = "b2c_1_reset";
        public static string Authority = "https://login.microsoftonline.com/fabrikamb2c.onmicrosoft.com/";
        

        // Test Tenant and Policies
        /*
        public static string ApplicationID = "377cd8c6-a9df-4a55-aac5-8055475a550f";
        public static string SignUpSignInPolicy = "B2C_1_DefaultSignInSignUp";
        public static string ResetPasswordPolicy = "B2C_1_DefaultSignInSignUp";
        public static string Authority = "https://login.microsoftonline.com/BlueMetalElkay.onmicrosoft.com/";
        */

        public static string[] Scopes = { ApplicationID };
    }
}

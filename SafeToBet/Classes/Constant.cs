using System;
namespace SafeToBet.Classes
{
    public class Constant
    {
        public static String APP_NAME = "SafeToBet";
        public static String OK = "OK";
        public static String Username = "Admin";
        public static String Password = "123456";

        //AlertMessages

        public static String WRONG = "Something went wrong, re-start";
        public static String CREATE_ACCOUNT = "Do you want to create this account?";
        public static String DELETE_ACCOUNT = "Are you sure you want to delete your account?";
        public static String LOGIN_SUCCESS = "You are logged in successfully";
        public static String SIGNUP_SUCCESS = "You are signed in successfully";
        public static String LOGIN_FAILURE = "Your Username or password is incorrect";
        public static String SIGNUP_USER_EXIST = "This Phone number is already exists";
        public static String LOGOUT_MESSAGE = "Are you sure you want to logout";
        public static String RE_LOGIN_MESSAGE = "Password changed successfully, Re-Login with your new Password";
        public static String DELETE_MESSAGE = "Are you sure you want to delete your account?";
        public static String NO = "NO";
        public static String YES = "YES";

        //ValidationMessages

        public static String ENTER_EMAIL = "Please enter e-mail address";
        public static String ENTER_NAME = "Please enter Username";
        public static String ENTER_PHONE = "Please enter phone number";
        public static String ENTER_VALID_PHONE = "Please enter valid phone number";
        public static String ENTER_PASSWORD = "Please enter New password";
        public static String INCORRECT_OLD_PASSWORD = "Your Old Password is incorrect";
        public static String INCORRECT_NEW_PASSWORD = "Your New Password doesn't match the Confirm New Password";
        public static String ENTER_CONFIRM_PASSWORD = "Please enter confirm password";
        public static String ENTER_SHORT_PASSWORD = "Password should contain at least 6 characters";
        public static String PASSWORD_NOT_MATCH = "Password and confirm password does not match";
        public static String INCORRECT_LOGIN_CREDENTIAL = "E-mail address or password is incorrect";


    }
}

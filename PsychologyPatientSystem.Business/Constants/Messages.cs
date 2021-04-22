using System;
using System.Collections.Generic;
using System.Text;
using PsychologyPatientSystem.Core.Entities.Concrete;

namespace PsychologyPatientSystem.Business.Constants
{
 public    static class Messages
 {
     public static string hastaaynıolamaz = "Hasta ismi aynı olamaz!";
     public static string PasswordError = "Şifreniz Uyuşmuyor";
     public static string UserNotFound = "Kullanıcı Bulanamadı";
     public static string SuccessfulLogin = "Giriş Başarılı";
     public static string UserAlreadyExits = "Bu Kullanici Zaten Mevcut";
     public static string UserRegistered = "Kullanıcı Başarıyla Eklendi";
     public static string AccessTokenCreated = "Access Token Oluşturuldu";
 }
}

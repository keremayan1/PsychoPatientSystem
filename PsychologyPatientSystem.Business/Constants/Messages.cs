using System;
using System.Collections.Generic;
using System.Text;
using PsychologyPatientSystem.Core.Entities.Concrete;

namespace PsychologyPatientSystem.Business.Constants
{
    public static class Messages
    {
        //Patient Messages
        public static string PatientsAlreadyExits = "Birden Fazla Aynı Hastadan Olamaz!";
        public static string PatientsGetAll = "Hastalar Getirildi";
        public static string PatientsGetById = "Hasta TC-Kimlik Numarasına Göre Getirildi";
        public static string AddedPatients = "Hasta Kayıt İşlemi Başarılı";
        public static string DeletedPatients = "Hasta Silme İşlemi Başarılı";
        public static string UpdatedPatients = "Hasta Güncelleme İşlemi Başarılı";
        
        
        
        //Login and Register Messages
        public static string PasswordError = "Şifreniz Uyuşmuyor";
        public static string UserNotFound = "Kullanıcı Bulanamadı";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExits = "Bu Kullanici Zaten Mevcut";
        public static string UserRegistered = "Kullanıcı Başarıyla Eklendi";
        public static string AccessTokenCreated = "Access Token Oluşturuldu";

        //Roles
        public static string NotAccessRoles = "Yetkiniz Yok";
    }
}

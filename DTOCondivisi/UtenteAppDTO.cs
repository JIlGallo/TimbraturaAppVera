using it.Mifram.Dieci3k.DTO.Support;
using it.Mifram.Dieci3k.Enums.NetSt;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace it.Mifram.Dieci3k.DTO.Anagrafiche
{
    [Serializable]
    public class UtenteAppDTO:BaseDTO
    {
        private ERuoloUtente _RuoloUtente;
        private byte _IsEnable;
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string NotificationsTag { get; set; }
        public char? Salt { get; set; }
        public byte IsEnable
        {
            get { return _IsEnable; }
            set
            {
                _IsEnable = value;
                OnPropertyChanged();
            }
        }
        public bool IsEnableBool
        {
            get
            {
                if (IsEnable == 1)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value == true)
                    IsEnable = 1;
                else
                    IsEnable = 0;
            }
        }
        public int CompanyId { get; set; }
        public CompanyDTO Company { get; set; }
        public ERuoloUtente RuoloUtente
        {
            get { return _RuoloUtente; }
            set
            {
                _RuoloUtente = value;
                OnPropertyChanged();
            }
        }

        public UtenteAppDTO()
        {
            IsEnable = 1;
            RiferimentiEsterni = new List<UtenteExtRifDTO>();
            Token = string.Empty;
            NotificationsTag = string.Empty;    
            Salt = (char)0;
            ErrorNumber = 0;
            DeviceId = string.Empty;

        }
        public UtenteAppDTO(int companyId):this()
        {
            this.CompanyId = companyId;
        }
        public List<UtenteExtRifDTO> RiferimentiEsterni { get; set; }
        public string DeviceId { get; set; }
        public int ErrorNumber { get; set; }
        public List<CustomMenuDTO> MenuUtente { get; set; } =  new List<CustomMenuDTO>();
        public List<UserMenuDTO> UsersMenu { get; set; } = new List<UserMenuDTO>();

        [JsonIgnore]
        public int AutistaId
        {
            get
            {
                int ret = 0;
                if (RiferimentiEsterni.Any(x => x.UserId == Id && x.TipoEntitaD3K == ETipoEntitaD3k.Autista))
                    ret = RiferimentiEsterni.First(x => x.UserId == Id && x.TipoEntitaD3K == ETipoEntitaD3k.Autista).ExtId;
                return ret;

            }
            set
            {
                if (RiferimentiEsterni.Any(x => x.UserId == Id && x.TipoEntitaD3K == ETipoEntitaD3k.Autista))
                {
                    UtenteExtRifDTO utenteExtRif = RiferimentiEsterni.First(x => x.UserId == Id && x.TipoEntitaD3K == ETipoEntitaD3k.Autista);
                    if (utenteExtRif.ExtId != value)
                        utenteExtRif.ExtId = value;
                }
                else
                    RiferimentiEsterni.Add(new UtenteExtRifDTO(Id, value, ETipoEntitaD3k.Autista));
            }
        }
        [JsonIgnore]
        public int DipendenteId
        {
            get
            {
                int ret = 0;
                if (RiferimentiEsterni.Any(x => x.UserId == Id && x.TipoEntitaD3K == ETipoEntitaD3k.Dipendente))
                    ret = RiferimentiEsterni.First(x => x.UserId == Id && x.TipoEntitaD3K == ETipoEntitaD3k.Dipendente).ExtId;
                return ret;

            }
            set
            {
                if (RiferimentiEsterni.Any(x => x.UserId == Id && x.TipoEntitaD3K == ETipoEntitaD3k.Dipendente))
                {
                    UtenteExtRifDTO utenteExtRif = RiferimentiEsterni.First(x => x.UserId == Id && x.TipoEntitaD3K == ETipoEntitaD3k.Dipendente);
                    if (utenteExtRif.ExtId != value)
                        utenteExtRif.ExtId = value;
                }
                else
                    RiferimentiEsterni.Add(new UtenteExtRifDTO(Id, value, ETipoEntitaD3k.Dipendente));
            }
        }
        [JsonIgnore]
        public int D3kId
        {
            get
            {
                int ret = 0;
                if (RiferimentiEsterni.Any(x => x.UserId == Id && x.TipoEntitaD3K == ETipoEntitaD3k.Utente))
                    ret = RiferimentiEsterni.First(x => x.UserId == Id && x.TipoEntitaD3K == ETipoEntitaD3k.Utente).ExtId;
                return ret;
            }
            set
            {
                if (RiferimentiEsterni.Any(x => x.UserId == Id && x.TipoEntitaD3K == ETipoEntitaD3k.Utente))
                {
                    UtenteExtRifDTO utenteExtRif = RiferimentiEsterni.First(x => x.UserId == Id && x.TipoEntitaD3K == ETipoEntitaD3k.Utente);
                    if (utenteExtRif.ExtId != value)
                        utenteExtRif.ExtId = value;
                }
                else
                    RiferimentiEsterni.Add(new UtenteExtRifDTO(Id, value, ETipoEntitaD3k.Utente));
            }

        }
    }
}

namespace FTP_Server
{
    public class FTP
    {

        //CDUP - Change to Parent Directory
        // SMNT - Structure Mount
        // STOU - Store Unique
        // RMD - Remove Directory
        // MKD - Make Directory
        // PWD - Print Directory
        // SYST - System
        enum Commands
        {
            CDUP,
            SMNT,
            STOU,
            RMD,
            MKD,
            PWD,
            SYST,
        }
        enum AccessControl
        {
            USER,
            PASS,
            ACCT,
            CWD,
            CDUP,
            SMNT,
            REIN,
            QUIT,
        }
        enum FileTransferCommands
        {
            PORT,
            PASV,
            TYPE,
            STRU,
        }
        enum ServiceCommands
        {
            RETR,
            STOR,
            APPE,
            ALLO,
            REST,
            RNTO,
            ABOR,
            DELE,
            RMD,
            MKD,
            PWD,
            LIST,
            NLST,
            SITE,
            SYST,
            STAT,
            HELP,
            NOOP,

        }

    }
}


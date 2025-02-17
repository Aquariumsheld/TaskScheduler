using System;
using System.Collections.Generic;

namespace TranslationsLibrary
{
    public static class TranslationManager
    {
        private static string CurrentLanguage = GetCurrentLanguage();
        /// <summary>
        /// Ist Das Dictionary für die übersetzung. Darf nur über die dafür vorgesehene methode aufgerufen werden
        /// Die übergebenen Parameter definieren dabei die jeweiligen Schwellenwerte.
        /// </summary>
        public static readonly Dictionary<string, Dictionary<string, string>> translations = new()
        {
            {
                "de", new Dictionary<string, string>
                {
                    #region ConsolenTranslation
                    //Test
                    { "welcome", "Willkommen im Hauptmenü:" },

                    //Language Menü
                    { "language_option", "Sprache ändern" },


                    //Mainmenu
                    { "headline_mainmenu", "Hauptmenü" },
                    { "newtask_options_mainmenu", "[ neuen Task erstellen ]" },
                    { "showtask_options_mainmenu", "[ alle Tasks anzeigen ]" },
                    { "loadpreset_options_mainmenu", "[ Voreinstellungen laden ]" },
                    { "settings_options_mainmenu", "[ Einstellungen ]" },
                    { "end_options_mainmenu", "[ Beenden ]" },
                    { "choose_language", "Wähle eine Sprache:" },
                    { "back_option", "Zurück zum Hauptmenü" },
                    #endregion

                    #region Settingsmenu
                    { "headline_settingsmenu", "Einstellungen" },
                    { "taskpreset_options_settingsmenu", "[ Voreinstellungen für neue Tasks]" },
                    { "language_options_settingsmenu", "[ Sprachen ]" },
                    { "back_options_settingsmenu", "[ zurück ]" },
                    #endregion

                    #region Basic Tasks (E-Mail)
                    { "openmail_executed_mail_basictasks", "Email Programm wurde gestartet" },
                    { "reciever_mail_basictasks", "empfänger@example.com" },
                    { "subject_mail_basictasks", "Betreff der E-Mail" },
                    { "text_mail_basictasks", "Hallo,\n\nDas ist eine vorgefertigte Nachricht." },
                    { "openmail_error_executed_mail_basictasks", "Fehler beim öffnen des E-Mail Clients: " },
                    #endregion

                    #region Basic Tasks (Calculator)
                    { "opencalc_executed_calculator_basictasks", "Taschenrechner wurde gestartet" },
                    { "opencalc_error_executed_calculator_basictasks", "Fehler beim Öffnen des Taschenrechners: " },
                    #endregion

                    #region Basic Tasks (Browser & LockInactive)
                    { "openbrowser_executed_browser_basictasks", "Browser wurde gestartet" },
                    { "lockinactive_basictasks", "Nutzer inaktiv: PC wird gesperrt" },
                    #endregion

                    #region BackupManager
                    //BackupManager.cs
                    { "specify_source_destination_folder_button_backup_start_click_backupmanager", "Bitte wähle einen Quell- und Zielordner" },
                    { "manual_automationmethod_backupmanager", "Manuell" },
                    { "scheduled_automationmethod_backupmanager", "Geplant" },
                    { "scheduled_started_automationmethod_backupmanager", "Geplante Backups gestartet (Intervall: 60 Sekunden)." },
                    { "realtime_automationmethod_backupmanager", "Echtzeit" },
                    { "realtime_started_automationmethod_backupmanager", "Echtzeit-Backup aktiviert. Änderungen werden überwacht." },
                    { "backupfailed_backupmanager", "Backup fehlgeschlagen: " },
                    { "automation_stopped_backupmanager", "Automatisierung gestoppt." },
                    { "choose_source_folder_backupmanager", "Quellordner auswählen" },
                    { "choose_destination_folder_backupmanager", "Zielordner auswählen" },

                    //Backuptype
                    { "complete_backuptype_backupmanager", "Vollständig" },
                    { "incremental_backuptype_backupmanager", "Inkrementell" },
                    { "differential_backuptype_backupmanager", "Differenziell" },
                    { "synchronize_backuptype_backupmanager", "Syncronisieren" },
                    { "unknown_backuptype_backupmanager", "Unbekannter Backup-Typ" },

                    //BackupManager.designer.cs
                    { "source_folder_designer_backupmanager", "Quellordner" },
                    { "searching_designer_backupmanager", "Durchsuchen..." },
                    { "destination_folder_designer_backupmanager", "Zielordner:" },
                    { "backuptype_designer_backupmanager", "Backup-Typ:" },
                    { "automation_designer_backupmanager", "Automatisierung:" },
                    { "startbackup_designer_backupmanager", "Backup starten" },
                    { "stopautomation_designer_backupmanager", "Automatisierung stoppen" },
                    #endregion

                    #region PreventShutdown
                    { "shutdown_prevented_preventshutdown", "Herunterfahren wird durch diese Anwendung verhindert." },
                    #endregion

                    #region TaskCreator
                    //TaskCreator.cs
                    { "veryimportant_prioritys_taskcreator", "sehr wichtig" },
                    { "important_prioritys_taskcreator", "wichtig" },
                    { "normalimportant_prioritys_taskcreator", "normal" },
                    { "lessimportant_prioritys_taskcreator", "unwichtig" },
                    { "leastimportant_prioritys_taskcreator", "sehr unwichtig" },
                    { "priority_taskcreator", "Priorität" },
                    { "unit_taskcreator", "Priorität" },

                    //TaskCreator.designer.cs
                    { "name_designer_taskcreator", "Name" },
                    { "choise_designer_taskcreator", "Auswählen" },
                    { "recurring_designer_taskcreator", "wiederkehrend" },
                    { "filePath_designer_taskcreator", "Dateipfad" },
                    { "save_designer_taskcreator", "Speichern" },
                    { "cancel_designer_taskcreator", "Abbrechen" },
                    #endregion

                    #region Enum UnitFactors
                    { "seconds_unitfactors_designer_taskcreator", "Sekunden" },
                    { "minutes_unitfactors_designer_taskcreator", "Minuten" },
                    { "hours_unitfactors_designer_taskcreator", "Stunden" },
                    { "days_unitfactors_designer_taskcreator", "Tage" },
                    { "weeks_unitfactors_designer_taskcreator", "Wochen" },
                    #endregion
                }
            },
            {
                "en", new Dictionary<string, string>
                {
                    #region ConsolenTranslation
                    { "welcome", "Welcome to the main menu:" },
                    { "language_option", "Change language" },
                    { "headline_mainmenu", "Main Menu" },
                    { "newtask_options_mainmenu", "[ Create new task ]" },
                    { "showtask_options_mainmenu", "[ Show all tasks ]" },
                    { "loadpreset_options_mainmenu", "[ Load presets ]" },
                    { "settings_options_mainmenu", "[ Settings ]" },
                    { "end_options_mainmenu", "[ Exit ]" },
                    { "choose_language", "Choose a language:" },
                    { "back_option", "Back to main menu" },
                    #endregion

                    #region Settingsmenu
                    { "headline_settingsmenu", "Settings" },
                    { "taskpreset_options_settingsmenu", "[ Presets for new tasks ]" },
                    { "language_options_settingsmenu", "[ Languages ]" },
                    { "back_options_settingsmenu", "[ Back ]" },
                    #endregion

                    #region Basic Tasks (E-Mail)
                    { "openmail_executed_mail_basictasks", "Email program started" },
                    { "reciever_mail_basictasks", "recipient@example.com" },
                    { "subject_mail_basictasks", "Email subject" },
                    { "text_mail_basictasks", "Hello,\n\nThis is a preset message." },
                    { "openmail_error_executed_mail_basictasks", "Error opening email client: " },
                    #endregion

                    #region Basic Tasks (Calculator)
                    { "opencalc_executed_calculator_basictasks", "Calculator started" },
                    { "opencalc_error_executed_calculator_basictasks", "Error opening calculator: " },
                    #endregion

                    #region Basic Tasks (Browser & LockInactive)
                    { "openbrowser_executed_browser_basictasks", "Browser started" },
                    { "lockinactive_basictasks", "User inactive: PC will be locked" },
                    #endregion

                    #region BackupManager
                    { "specify_source_destination_folder_button_backup_start_click_backupmanager", "Please select a source and destination folder" },
                    { "manual_automationmethod_backupmanager", "Manual" },
                    { "scheduled_automationmethod_backupmanager", "Scheduled" },
                    { "scheduled_started_automationmethod_backupmanager", "Scheduled backups started (interval: 60 seconds)." },
                    { "realtime_automationmethod_backupmanager", "Real-time" },
                    { "realtime_started_automationmethod_backupmanager", "Real-time backup activated. Monitoring changes." },
                    { "backupfailed_backupmanager", "Backup failed: " },
                    { "automation_stopped_backupmanager", "Automation stopped." },
                    { "choose_source_folder_backupmanager", "Select source folder" },
                    { "choose_destination_folder_backupmanager", "Select destination folder" },
                    #endregion

                    #region Backuptype
                    { "complete_backuptype_backupmanager", "Full" },
                    { "incremental_backuptype_backupmanager", "Incremental" },
                    { "differential_backuptype_backupmanager", "Differential" },
                    { "synchronize_backuptype_backupmanager", "Synchronize" },
                    { "unknown_backuptype_backupmanager", "Unknown backup type" },
                    #endregion

                    #region BackupManager.designer.cs
                    { "source_folder_designer_backupmanager", "Source folder" },
                    { "searching_designer_backupmanager", "Browse..." },
                    { "destination_folder_designer_backupmanager", "Destination folder:" },
                    { "backuptype_designer_backupmanager", "Backup type:" },
                    { "automation_designer_backupmanager", "Automation:" },
                    { "startbackup_designer_backupmanager", "Start backup" },
                    { "stopautomation_designer_backupmanager", "Stop automation" },
                    #endregion

                    #region PreventShutdown
                    { "shutdown_prevented_preventshutdown", "Shutdown is prevented by this application." },
                    #endregion

                    #region TaskCreator
                    { "veryimportant_prioritys_taskcreator", "very important" },
                    { "important_prioritys_taskcreator", "important" },
                    { "normalimportant_prioritys_taskcreator", "normal" },
                    { "lessimportant_prioritys_taskcreator", "not important" },
                    { "leastimportant_prioritys_taskcreator", "least important" },
                    { "priority_taskcreator", "Priority" },
                    { "unit_taskcreator", "Priority" },
                    { "name_designer_taskcreator", "Name" },
                    { "choise_designer_taskcreator", "Select" },
                    { "recurring_designer_taskcreator", "Recurring" },
                    { "filePath_designer_taskcreator", "File path" },
                    { "save_designer_taskcreator", "Save" },
                    { "cancel_designer_taskcreator", "Cancel" },
                    #endregion

                    #region Enum UnitFactors
                    { "seconds_unitfactors_designer_taskcreator", "Seconds" },
                    { "minutes_unitfactors_designer_taskcreator", "Minutes" },
                    { "hours_unitfactors_designer_taskcreator", "Hours" },
                    { "days_unitfactors_designer_taskcreator", "Days" },
                    { "weeks_unitfactors_designer_taskcreator", "Weeks" },
                    #endregion
                }
            },
            {
                "fr", new Dictionary<string, string>
                {
                    #region ConsolenTranslation
                    { "welcome", "Bienvenue dans le menu principal :" },
                    { "language_option", "Changer la langue" },
                    { "headline_mainmenu", "Menu principal" },
                    { "newtask_options_mainmenu", "[ Créer une nouvelle tâche ]" },
                    { "showtask_options_mainmenu", "[ Afficher toutes les tâches ]" },
                    { "loadpreset_options_mainmenu", "[ Charger les préréglages ]" },
                    { "settings_options_mainmenu", "[ Paramètres ]" },
                    { "end_options_mainmenu", "[ Quitter ]" },
                    { "choose_language", "Choisissez une langue :" },
                    { "back_option", "Retour au menu principal" },
                    #endregion

                    #region Settingsmenu
                    { "headline_settingsmenu", "Paramètres" },
                    { "taskpreset_options_settingsmenu", "[ Préréglages pour nouvelles tâches ]" },
                    { "language_options_settingsmenu", "[ Langues ]" },
                    { "back_options_settingsmenu", "[ Retour ]" },
                    #endregion

                    #region Basic Tasks (E-Mail)
                    { "openmail_executed_mail_basictasks", "Le programme de messagerie a démarré" },
                    { "reciever_mail_basictasks", "destinataire@example.com" },
                    { "subject_mail_basictasks", "Objet du courriel" },
                    { "text_mail_basictasks", "Bonjour,\n\nCeci est un message prédéfini." },
                    { "openmail_error_executed_mail_basictasks", "Erreur lors de l'ouverture du client de messagerie : " },
                    #endregion

                    #region Basic Tasks (Calculator)
                    { "opencalc_executed_calculator_basictasks", "La calculatrice a démarré" },
                    { "opencalc_error_executed_calculator_basictasks", "Erreur lors de l'ouverture de la calculatrice : " },
                    #endregion

                    #region Basic Tasks (Browser & LockInactive)
                    { "openbrowser_executed_browser_basictasks", "Le navigateur a démarré" },
                    { "lockinactive_basictasks", "Utilisateur inactif : le PC sera verrouillé" },
                    #endregion

                    #region BackupManager
                    { "specify_source_destination_folder_button_backup_start_click_backupmanager", "Veuillez sélectionner un dossier source et un dossier de destination" },
                    { "manual_automationmethod_backupmanager", "Manuel" },
                    { "scheduled_automationmethod_backupmanager", "Planifié" },
                    { "scheduled_started_automationmethod_backupmanager", "Sauvegardes planifiées démarrées (intervalle : 60 secondes)." },
                    { "realtime_automationmethod_backupmanager", "Temps réel" },
                    { "realtime_started_automationmethod_backupmanager", "Sauvegarde en temps réel activée. Surveillance des modifications." },
                    { "backupfailed_backupmanager", "Échec de la sauvegarde : " },
                    { "automation_stopped_backupmanager", "Automatisation arrêtée." },
                    { "choose_source_folder_backupmanager", "Sélectionner le dossier source" },
                    { "choose_destination_folder_backupmanager", "Sélectionner le dossier de destination" },
                    #endregion

                    #region Backuptype
                    { "complete_backuptype_backupmanager", "Complet" },
                    { "incremental_backuptype_backupmanager", "Incrémental" },
                    { "differential_backuptype_backupmanager", "Différentiel" },
                    { "synchronize_backuptype_backupmanager", "Synchroniser" },
                    { "unknown_backuptype_backupmanager", "Type de sauvegarde inconnu" },
                    #endregion

                    #region BackupManager.designer.cs
                    { "source_folder_designer_backupmanager", "Dossier source" },
                    { "searching_designer_backupmanager", "Parcourir..." },
                    { "destination_folder_designer_backupmanager", "Dossier de destination :" },
                    { "backuptype_designer_backupmanager", "Type de sauvegarde :" },
                    { "automation_designer_backupmanager", "Automatisation :" },
                    { "startbackup_designer_backupmanager", "Démarrer la sauvegarde" },
                    { "stopautomation_designer_backupmanager", "Arrêter l'automatisation" },
                    #endregion

                    #region PreventShutdown
                    { "shutdown_prevented_preventshutdown", "L'arrêt est empêché par cette application." },
                    #endregion

                    #region TaskCreator
                    { "veryimportant_prioritys_taskcreator", "très important" },
                    { "important_prioritys_taskcreator", "important" },
                    { "normalimportant_prioritys_taskcreator", "normal" },
                    { "lessimportant_prioritys_taskcreator", "peu important" },
                    { "leastimportant_prioritys_taskcreator", "le moins important" },
                    { "priority_taskcreator", "Priorité" },
                    { "unit_taskcreator", "Priorité" },
                    { "name_designer_taskcreator", "Nom" },
                    { "choise_designer_taskcreator", "Sélectionner" },
                    { "recurring_designer_taskcreator", "récurrent" },
                    { "filePath_designer_taskcreator", "Chemin du fichier" },
                    { "save_designer_taskcreator", "Enregistrer" },
                    { "cancel_designer_taskcreator", "Annuler" },
                    #endregion

                    #region Enum UnitFactors
                    { "seconds_unitfactors_designer_taskcreator", "Secondes" },
                    { "minutes_unitfactors_designer_taskcreator", "Minutes" },
                    { "hours_unitfactors_designer_taskcreator", "Heures" },
                    { "days_unitfactors_designer_taskcreator", "Jours" },
                    { "weeks_unitfactors_designer_taskcreator", "Semaines" },
                    #endregion
                }
            },
            {
                "it", new Dictionary<string, string>
                {
                    #region ConsolenTranslation
                    { "welcome", "Benvenuto nel menu principale:" },
                    { "language_option", "Cambia lingua" },
                    { "headline_mainmenu", "Menu Principale" },
                    { "newtask_options_mainmenu", "[ Crea nuovo task ]" },
                    { "showtask_options_mainmenu", "[ Mostra tutti i task ]" },
                    { "loadpreset_options_mainmenu", "[ Carica preset ]" },
                    { "settings_options_mainmenu", "[ Impostazioni ]" },
                    { "end_options_mainmenu", "[ Esci ]" },
                    { "choose_language", "Scegli una lingua:" },
                    { "back_option", "Torna al menu principale" },
                    #endregion

                    #region Settingsmenu
                    { "headline_settingsmenu", "Impostazioni" },
                    { "taskpreset_options_settingsmenu", "[ Preset per nuovi task ]" },
                    { "language_options_settingsmenu", "[ Lingue ]" },
                    { "back_options_settingsmenu", "[ Indietro ]" },
                    #endregion

                    #region Basic Tasks (E-Mail)
                    { "openmail_executed_mail_basictasks", "Il programma di posta elettronica è stato avviato" },
                    { "reciever_mail_basictasks", "destinatario@example.com" },
                    { "subject_mail_basictasks", "Oggetto dell'email" },
                    { "text_mail_basictasks", "Ciao,\n\nQuesto è un messaggio predefinito." },
                    { "openmail_error_executed_mail_basictasks", "Errore durante l'apertura del client di posta: " },
                    #endregion

                    #region Basic Tasks (Calculator)
                    { "opencalc_executed_calculator_basictasks", "La calcolatrice è stata avviata" },
                    { "opencalc_error_executed_calculator_basictasks", "Errore durante l'apertura della calcolatrice: " },
                    #endregion

                    #region Basic Tasks (Browser & LockInactive)
                    { "openbrowser_executed_browser_basictasks", "Il browser è stato avviato" },
                    { "lockinactive_basictasks", "Utente inattivo: il PC verrà bloccato" },
                    #endregion

                    #region BackupManager
                    { "specify_source_destination_folder_button_backup_start_click_backupmanager", "Seleziona una cartella di origine e una di destinazione" },
                    { "manual_automationmethod_backupmanager", "Manuale" },
                    { "scheduled_automationmethod_backupmanager", "Programmato" },
                    { "scheduled_started_automationmethod_backupmanager", "Backup programmati avviati (intervallo: 60 secondi)." },
                    { "realtime_automationmethod_backupmanager", "In tempo reale" },
                    { "realtime_started_automationmethod_backupmanager", "Backup in tempo reale attivato. Monitoraggio delle modifiche." },
                    { "backupfailed_backupmanager", "Backup fallito: " },
                    { "automation_stopped_backupmanager", "Automazione interrotta." },
                    { "choose_source_folder_backupmanager", "Seleziona la cartella di origine" },
                    { "choose_destination_folder_backupmanager", "Seleziona la cartella di destinazione" },
                    #endregion

                    #region Backuptype
                    { "complete_backuptype_backupmanager", "Completo" },
                    { "incremental_backuptype_backupmanager", "Incrementale" },
                    { "differential_backuptype_backupmanager", "Differenziale" },
                    { "synchronize_backuptype_backupmanager", "Sincronizza" },
                    { "unknown_backuptype_backupmanager", "Tipo di backup sconosciuto" },
                    #endregion

                    #region BackupManager.designer.cs
                    { "source_folder_designer_backupmanager", "Cartella di origine" },
                    { "searching_designer_backupmanager", "Sfoglia..." },
                    { "destination_folder_designer_backupmanager", "Cartella di destinazione:" },
                    { "backuptype_designer_backupmanager", "Tipo di backup:" },
                    { "automation_designer_backupmanager", "Automazione:" },
                    { "startbackup_designer_backupmanager", "Avvia backup" },
                    { "stopautomation_designer_backupmanager", "Ferma automazione" },
                    #endregion

                    #region PreventShutdown
                    { "shutdown_prevented_preventshutdown", "Lo spegnimento è impedito da questa applicazione." },
                    #endregion

                    #region TaskCreator
                    { "veryimportant_prioritys_taskcreator", "molto importante" },
                    { "important_prioritys_taskcreator", "importante" },
                    { "normalimportant_prioritys_taskcreator", "normale" },
                    { "lessimportant_prioritys_taskcreator", "meno importante" },
                    { "leastimportant_prioritys_taskcreator", "poco importante" },
                    { "priority_taskcreator", "Priorità" },
                    { "unit_taskcreator", "Priorità" },
                    { "name_designer_taskcreator", "Nome" },
                    { "choise_designer_taskcreator", "Seleziona" },
                    { "recurring_designer_taskcreator", "ricorrente" },
                    { "filePath_designer_taskcreator", "Percorso del file" },
                    { "save_designer_taskcreator", "Salva" },
                    { "cancel_designer_taskcreator", "Annulla" },
                    #endregion

                    #region Enum UnitFactors
                    { "seconds_unitfactors_designer_taskcreator", "Secondi" },
                    { "minutes_unitfactors_designer_taskcreator", "Minuti" },
                    { "hours_unitfactors_designer_taskcreator", "Ore" },
                    { "days_unitfactors_designer_taskcreator", "Giorni" },
                    { "weeks_unitfactors_designer_taskcreator", "Settimane" },
                    #endregion
                }
            },
            {
                "es", new Dictionary<string, string>
                {
                    #region ConsolenTranslation
                    { "welcome", "Bienvenido al menú principal:" },
                    { "language_option", "Cambiar idioma" },
                    { "headline_mainmenu", "Menú principal" },
                    { "newtask_options_mainmenu", "[ Crear nueva tarea ]" },
                    { "showtask_options_mainmenu", "[ Mostrar todas las tareas ]" },
                    { "loadpreset_options_mainmenu", "[ Cargar preajustes ]" },
                    { "settings_options_mainmenu", "[ Configuración ]" },
                    { "end_options_mainmenu", "[ Salir ]" },
                    { "choose_language", "Elige un idioma:" },
                    { "back_option", "Volver al menú principal" },
                    #endregion

                    #region Settingsmenu
                    { "headline_settingsmenu", "Configuración" },
                    { "taskpreset_options_settingsmenu", "[ Preajustes para nuevas tareas ]" },
                    { "language_options_settingsmenu", "[ Idiomas ]" },
                    { "back_options_settingsmenu", "[ Atrás ]" },
                    #endregion

                    #region Basic Tasks (E-Mail)
                    { "openmail_executed_mail_basictasks", "El programa de correo ha iniciado" },
                    { "reciever_mail_basictasks", "destinatario@example.com" },
                    { "subject_mail_basictasks", "Asunto del correo" },
                    { "text_mail_basictasks", "Hola,\n\nEste es un mensaje preestablecido." },
                    { "openmail_error_executed_mail_basictasks", "Error al abrir el cliente de correo: " },
                    #endregion

                    #region Basic Tasks (Calculator)
                    { "opencalc_executed_calculator_basictasks", "La calculadora se ha iniciado" },
                    { "opencalc_error_executed_calculator_basictasks", "Error al abrir la calculadora: " },
                    #endregion

                    #region Basic Tasks (Browser & LockInactive)
                    { "openbrowser_executed_browser_basictasks", "El navegador se ha iniciado" },
                    { "lockinactive_basictasks", "Usuario inactivo: el PC se bloqueará" },
                    #endregion

                    #region BackupManager
                    { "specify_source_destination_folder_button_backup_start_click_backupmanager", "Por favor, selecciona una carpeta de origen y destino" },
                    { "manual_automationmethod_backupmanager", "Manual" },
                    { "scheduled_automationmethod_backupmanager", "Programado" },
                    { "scheduled_started_automationmethod_backupmanager", "Copias de seguridad programadas iniciadas (intervalo: 60 segundos)." },
                    { "realtime_automationmethod_backupmanager", "En tiempo real" },
                    { "realtime_started_automationmethod_backupmanager", "Copia de seguridad en tiempo real activada. Monitoreando cambios." },
                    { "backupfailed_backupmanager", "Copia de seguridad fallida: " },
                    { "automation_stopped_backupmanager", "Automatización detenida." },
                    { "choose_source_folder_backupmanager", "Seleccionar carpeta de origen" },
                    { "choose_destination_folder_backupmanager", "Seleccionar carpeta de destino" },
                    #endregion

                    #region Backuptype
                    { "complete_backuptype_backupmanager", "Completo" },
                    { "incremental_backuptype_backupmanager", "Incremental" },
                    { "differential_backuptype_backupmanager", "Diferencial" },
                    { "synchronize_backuptype_backupmanager", "Sincronizar" },
                    { "unknown_backuptype_backupmanager", "Tipo de copia de seguridad desconocido" },
                    #endregion

                    #region BackupManager.designer.cs
                    { "source_folder_designer_backupmanager", "Carpeta de origen" },
                    { "searching_designer_backupmanager", "Buscar..." },
                    { "destination_folder_designer_backupmanager", "Carpeta de destino:" },
                    { "backuptype_designer_backupmanager", "Tipo de copia de seguridad:" },
                    { "automation_designer_backupmanager", "Automatización:" },
                    { "startbackup_designer_backupmanager", "Iniciar copia de seguridad" },
                    { "stopautomation_designer_backupmanager", "Detener automatización" },
                    #endregion

                    #region PreventShutdown
                    { "shutdown_prevented_preventshutdown", "El apagado es prevenido por esta aplicación." },
                    #endregion

                    #region TaskCreator
                    { "veryimportant_prioritys_taskcreator", "muy importante" },
                    { "important_prioritys_taskcreator", "importante" },
                    { "normalimportant_prioritys_taskcreator", "normal" },
                    { "lessimportant_prioritys_taskcreator", "poco importante" },
                    { "leastimportant_prioritys_taskcreator", "menos importante" },
                    { "priority_taskcreator", "Prioridad" },
                    { "unit_taskcreator", "Prioridad" },
                    { "name_designer_taskcreator", "Nombre" },
                    { "choise_designer_taskcreator", "Seleccionar" },
                    { "recurring_designer_taskcreator", "recurrente" },
                    { "filePath_designer_taskcreator", "Ruta del archivo" },
                    { "save_designer_taskcreator", "Guardar" },
                    { "cancel_designer_taskcreator", "Cancelar" },
                    #endregion

                    #region Enum UnitFactors
                    { "seconds_unitfactors_designer_taskcreator", "Segundos" },
                    { "minutes_unitfactors_designer_taskcreator", "Minutos" },
                    { "hours_unitfactors_designer_taskcreator", "Horas" },
                    { "days_unitfactors_designer_taskcreator", "Días" },
                    { "weeks_unitfactors_designer_taskcreator", "Semanas" },
                    #endregion
                }
            },
            {
                "zh", new Dictionary<string, string>
                {
                    #region ConsolenTranslation
                    { "welcome", "欢迎进入主菜单：" },
                    { "language_option", "更改语言" },
                    { "headline_mainmenu", "主菜单" },
                    { "newtask_options_mainmenu", "[ 创建新任务 ]" },
                    { "showtask_options_mainmenu", "[ 显示所有任务 ]" },
                    { "loadpreset_options_mainmenu", "[ 加载预设 ]" },
                    { "settings_options_mainmenu", "[ 设置 ]" },
                    { "end_options_mainmenu", "[ 退出 ]" },
                    { "choose_language", "选择语言：" },
                    { "back_option", "返回主菜单" },
                    #endregion

                    #region Settingsmenu
                    { "headline_settingsmenu", "设置" },
                    { "taskpreset_options_settingsmenu", "[ 新任务预设 ]" },
                    { "language_options_settingsmenu", "[ 语言 ]" },
                    { "back_options_settingsmenu", "[ 返回 ]" },
                    #endregion

                    #region Basic Tasks (E-Mail)
                    { "openmail_executed_mail_basictasks", "邮件程序已启动" },
                    { "reciever_mail_basictasks", "收件人@example.com" },
                    { "subject_mail_basictasks", "邮件主题" },
                    { "text_mail_basictasks", "你好,\n\n这是一条预设消息。" },
                    { "openmail_error_executed_mail_basictasks", "打开邮件客户端时出错： " },
                    #endregion

                    #region Basic Tasks (Calculator)
                    { "opencalc_executed_calculator_basictasks", "计算器已启动" },
                    { "opencalc_error_executed_calculator_basictasks", "打开计算器时出错： " },
                    #endregion

                    #region Basic Tasks (Browser & LockInactive)
                    { "openbrowser_executed_browser_basictasks", "浏览器已启动" },
                    { "lockinactive_basictasks", "用户不活跃：电脑将被锁定" },
                    #endregion

                    #region BackupManager
                    { "specify_source_destination_folder_button_backup_start_click_backupmanager", "请选择源文件夹和目标文件夹" },
                    { "manual_automationmethod_backupmanager", "手动" },
                    { "scheduled_automationmethod_backupmanager", "定时" },
                    { "scheduled_started_automationmethod_backupmanager", "定时备份已启动（间隔：60秒）。" },
                    { "realtime_automationmethod_backupmanager", "实时" },
                    { "realtime_started_automationmethod_backupmanager", "实时备份已激活，正在监控更改。" },
                    { "backupfailed_backupmanager", "备份失败：" },
                    { "automation_stopped_backupmanager", "自动化已停止。" },
                    { "choose_source_folder_backupmanager", "选择源文件夹" },
                    { "choose_destination_folder_backupmanager", "选择目标文件夹" },
                    #endregion

                    #region Backuptype
                    { "complete_backuptype_backupmanager", "完整" },
                    { "incremental_backuptype_backupmanager", "增量" },
                    { "differential_backuptype_backupmanager", "差异" },
                    { "synchronize_backuptype_backupmanager", "同步" },
                    { "unknown_backuptype_backupmanager", "未知备份类型" },
                    #endregion

                    #region BackupManager.designer.cs
                    { "source_folder_designer_backupmanager", "源文件夹" },
                    { "searching_designer_backupmanager", "浏览..." },
                    { "destination_folder_designer_backupmanager", "目标文件夹：" },
                    { "backuptype_designer_backupmanager", "备份类型：" },
                    { "automation_designer_backupmanager", "自动化：" },
                    { "startbackup_designer_backupmanager", "启动备份" },
                    { "stopautomation_designer_backupmanager", "停止自动化" },
                    #endregion

                    #region PreventShutdown
                    { "shutdown_prevented_preventshutdown", "此应用程序阻止了关机。" },
                    #endregion

                    #region TaskCreator
                    { "veryimportant_prioritys_taskcreator", "非常重要" },
                    { "important_prioritys_taskcreator", "重要" },
                    { "normalimportant_prioritys_taskcreator", "正常" },
                    { "lessimportant_prioritys_taskcreator", "不太重要" },
                    { "leastimportant_prioritys_taskcreator", "最不重要" },
                    { "priority_taskcreator", "优先级" },
                    { "unit_taskcreator", "优先级" },
                    { "name_designer_taskcreator", "名称" },
                    { "choise_designer_taskcreator", "选择" },
                    { "recurring_designer_taskcreator", "重复" },
                    { "filePath_designer_taskcreator", "文件路径" },
                    { "save_designer_taskcreator", "保存" },
                    { "cancel_designer_taskcreator", "取消" },
                    #endregion

                    #region Enum UnitFactors
                    { "seconds_unitfactors_designer_taskcreator", "秒" },
                    { "minutes_unitfactors_designer_taskcreator", "分钟" },
                    { "hours_unitfactors_designer_taskcreator", "小时" },
                    { "days_unitfactors_designer_taskcreator", "天" },
                    { "weeks_unitfactors_designer_taskcreator", "周" },
                    #endregion
                }
            },
            {
                "hi", new Dictionary<string, string>
                {
                    #region ConsolenTranslation
                    { "welcome", "मुख्य मेनू में स्वागत है:" },
                    { "language_option", "भाषा बदलें" },
                    { "headline_mainmenu", "मुख्य मेनू" },
                    { "newtask_options_mainmenu", "[ नया कार्य बनाएं ]" },
                    { "showtask_options_mainmenu", "[ सभी कार्य दिखाएं ]" },
                    { "loadpreset_options_mainmenu", "[ पूर्वनिर्धारित सेटिंग लोड करें ]" },
                    { "settings_options_mainmenu", "[ सेटिंग्स ]" },
                    { "end_options_mainmenu", "[ बंद करें ]" },
                    { "choose_language", "एक भाषा चुनें:" },

                    #endregion

                    #region Settingsmenu
                    { "headline_settingsmenu", "सेटिंग्स" },
                    { "taskpreset_options_settingsmenu", "[ नए कार्य के लिए पूर्वनिर्धारित सेटिंग्स ]" },
                    { "language_options_settingsmenu", "[ भाषाएँ ]" },
                    { "back_options_settingsmenu", "[ वापस ]" },
                    #endregion

                    #region Basic Tasks (E-Mail)
                    { "openmail_executed_mail_basictasks", "ईमेल प्रोग्राम शुरू हो गया" },
                    { "reciever_mail_basictasks", "प्राप्तकर्ता@example.com" },
                    { "subject_mail_basictasks", "ईमेल का विषय" },
                    { "text_mail_basictasks", "नमस्ते,\n\nयह एक पूर्वनिर्धारित संदेश है।" },
                    { "openmail_error_executed_mail_basictasks", "ईमेल क्लाइंट खोलने में त्रुटि: " },
                    #endregion

                    #region Basic Tasks (Calculator)
                    { "opencalc_executed_calculator_basictasks", "कैलकुलेटर शुरू हो गया" },
                    { "opencalc_error_executed_calculator_basictasks", "कैलकुलेटर खोलने में त्रुटि: " },
                    #endregion

                    #region Basic Tasks (Browser & LockInactive)
                    { "openbrowser_executed_browser_basictasks", "ब्राउज़र शुरू हो गया" },
                    { "lockinactive_basictasks", "उपयोगकर्ता निष्क्रिय: पीसी लॉक हो रहा है" },
                    #endregion

                    #region BackupManager
                    { "specify_source_destination_folder_button_backup_start_click_backupmanager", "कृपया स्रोत और गंतव्य फ़ोल्डर चुनें" },
                    { "manual_automationmethod_backupmanager", "मैन्युअल" },
                    { "scheduled_automationmethod_backupmanager", "अनुसूचित" },
                    { "scheduled_started_automationmethod_backupmanager", "अनुसूचित बैकअप शुरू हो गए (अंतराल: 60 सेकंड)।" },
                    { "realtime_automationmethod_backupmanager", "रीयल-टाइम" },
                    { "realtime_started_automationmethod_backupmanager", "रीयल-टाइम बैकअप सक्रिय है। परिवर्तनों की निगरानी हो रही है।" },
                    { "backupfailed_backupmanager", "बैकअप विफल: " },
                    { "automation_stopped_backupmanager", "स्वचालन बंद किया गया।" },
                    { "choose_source_folder_backupmanager", "स्रोत फ़ोल्डर चुनें" },
                    { "choose_destination_folder_backupmanager", "गंतव्य फ़ोल्डर चुनें" },
                    #endregion

                    #region Backuptype
                    { "complete_backuptype_backupmanager", "पूर्ण" },
                    { "incremental_backuptype_backupmanager", "इनक्रिमेंटल" },
                    { "differential_backuptype_backupmanager", "डिफरेंशियल" },
                    { "synchronize_backuptype_backupmanager", "सिंक करें" },
                    { "unknown_backuptype_backupmanager", "अज्ञात बैकअप प्रकार" },
                    #endregion

                    #region BackupManager.designer.cs
                    { "source_folder_designer_backupmanager", "स्रोत फ़ोल्डर" },
                    { "searching_designer_backupmanager", "ब्राउज़ करें..." },
                    { "destination_folder_designer_backupmanager", "गंतव्य फ़ोल्डर:" },
                    { "backuptype_designer_backupmanager", "बैकअप प्रकार:" },
                    { "automation_designer_backupmanager", "स्वचालन:" },
                    { "startbackup_designer_backupmanager", "बैकअप शुरू करें" },
                    { "stopautomation_designer_backupmanager", "स्वचालन रोकें" },
                    #endregion

                    #region PreventShutdown
                    { "shutdown_prevented_preventshutdown", "इस एप्लिकेशन द्वारा शटडाउन रोका गया है।" },
                    #endregion

                    #region TaskCreator
                    { "veryimportant_prioritys_taskcreator", "बहुत महत्वपूर्ण" },
                    { "important_prioritys_taskcreator", "महत्वपूर्ण" },
                    { "normalimportant_prioritys_taskcreator", "साधारण" },
                    { "lessimportant_prioritys_taskcreator", "कम महत्वपूर्ण" },
                    { "leastimportant_prioritys_taskcreator", "सबसे कम महत्वपूर्ण" },
                    { "priority_taskcreator", "प्राथमिकता" },
                    { "unit_taskcreator", "प्राथमिकता" },
                    { "name_designer_taskcreator", "नाम" },
                    { "choise_designer_taskcreator", "चुनें" },
                    { "recurring_designer_taskcreator", "आवर्ती" },
                    { "filePath_designer_taskcreator", "फ़ाइल पथ" },
                    { "save_designer_taskcreator", "सहेजें" },
                    { "cancel_designer_taskcreator", "रद्द करें" },
                    #endregion

                    #region Enum UnitFactors
                    { "seconds_unitfactors_designer_taskcreator", "सेकंड" },
                    { "minutes_unitfactors_designer_taskcreator", "मिनट" },
                    { "hours_unitfactors_designer_taskcreator", "घंटे" },
                    { "days_unitfactors_designer_taskcreator", "दिन" },
                    { "weeks_unitfactors_designer_taskcreator", "हफ्ते" },
                    #endregion
                }
            },
            
            {
               "bd", new Dictionary<string, string>
               {
                   { "welcome", "Ozapft im Brauerei-Menü:" },
                   { "language_option", "Herkunft ändern" },
                   { "headline_mainmenu", "Zurück zur Brauerei" },
                   { "newtask_options_mainmenu", "[ Neue Gärung starten ]" },
                   { "showtask_options_mainmenu", "[ Alle Gärungen anzeigen ]" },
                   { "loadpreset_options_mainmenu", "[ Standard-Reinheitsgebot anwenden ]" },
                   { "settings_options_mainmenu", "[ Reinheitsgebot ]" },
                   { "end_options_mainmenu", "[ Krug auskippen]" },
                   { "back_option", "Zurück zur Brauerei" },
                   { "choose_option", "Entscheide dich für eine Sorte: " },

                   #region Settingsmenu
                   { "headline_settingsmenu", "Reinheitsgebot" },
                   { "taskpreset_options_settingsmenu", "[ Standard-Reinheitsgebot für neue Gärungen]" },
                   { "language_options_settingsmenu", "[ Herkunftsländer]" },
                   { "back_options_settingsmenu", "[ Krug zurückgeben ]" },
                   #endregion
                   #region Basic Tasks (E-Mail)
                   { "openmail_executed_mail_basictasks", "Bierpost wurde gestartet" },
                   { "reciever_mail_basictasks", "empfänger@example.com" },
                   { "subject_mail_basictasks", "Alkoholgehalt der Bierpost" },
                   { "text_mail_basictasks", "Servus!,\n\nDas ist eine vorgelederte Bierpost." },
                   { "openmail_error_executed_mail_basictasks", "Alkoholmangel beim Probieren des Bierpost-Klient: " },
                   #endregion
                   #region Basic Tasks (Calculator)
                   { "opencalc_executed_calculator_basictasks", "Alkoholrechner wurde gestartet" },
                   { "opencalc_error_executed_calculator_basictasks", "Alkoholmangel beim Anbixn des Alkoholrechners: " },
                   #endregion
                   #region Basic Tasks (Browser & LockInactive)
                   { "openbrowser_executed_browser_basictasks", "Weinlager wurde ozapft" },
                   { "lockinactive_basictasks", "Säufer bewusstlos: Fass wird weggerollt" },
                   #endregion
                   #region BackupManager
                   { "specify_source_destination_folder_button_backup_start_click_backupmanager", "Wähle eine Quelle und einen durstigen Mund" },
                   { "manual_automationmethod_backupmanager", "Hand anlegen" },
                   { "scheduled_automationmethod_backupmanager", "Vorglühen" },
                   { "scheduled_started_automationmethod_backupmanager", "Vorgeglühte Lederungen gestartet (Intervall: 60 Deutsche Sekunden)." },
                   { "realtime_automationmethod_backupmanager", "Grad eben" },
                   { "realtime_started_automationmethod_backupmanager", "GradEben-Lederung abgefüllt. Änderungen werden geniedert." },
                   { "backupfailed_backupmanager", "Lederung fehlgegärt: " },
                   { "automation_stopped_backupmanager", "Deckelung entzapft." },
                   { "choose_source_folder_backupmanager", "Quelle auswählen" },
                   { "choose_destination_folder_backupmanager", "Durstigen Mund auswählen" },
                   #endregion
                   #region Backuptype
                   { "complete_backuptype_backupmanager", "Komplett gegärt" },
                   { "incremental_backuptype_backupmanager", "Wachtmeisterig" },
                   { "differential_backuptype_backupmanager", "Wachtmoaschterig" },
                   { "synchronize_backuptype_backupmanager", "Kopfnussen" },
                   { "unknown_backuptype_backupmanager", "Nicht lederiger Lederung-Typ" },
                   #endregion
                   #region BackupManager.designer.cs
                   { "source_folder_designer_backupmanager", "Quelle" },
                   { "searching_designer_backupmanager", "Durchwachtmeistern..." },
                   { "destination_folder_designer_backupmanager", "Durstiger Mund:" },
                   { "backuptype_designer_backupmanager", "Lederung-Typ:" },
                   { "automation_designer_backupmanager", "Industrialisierung:" },
                   { "startbackup_designer_backupmanager", "Lederung starten" },
                   { "stopautomation_designer_backupmanager", "Industrialisierung stoppen" },
                   #endregion
                   #region PreventShutdown
                   { "shutdown_prevented_preventshutdown", "Entzapfen wird durch diese Flasche verboten." },
                   #endregion
                   #region TaskCreator
                   { "veryimportant_prioritys_taskcreator", "Fundamental" },
                   { "important_prioritys_taskcreator", "Basiert" },
                   { "normalimportant_prioritys_taskcreator", "Bodenständig" },
                   { "lessimportant_prioritys_taskcreator", "Sushko" },
                   { "leastimportant_prioritys_taskcreator", "Gehirnschimmel" },
                   { "priority_taskcreator", "Twix" },
                   { "unit_taskcreator", "Twix" },
                   { "name_designer_taskcreator", "Kennung" },
                   { "choise_designer_taskcreator", "Anledern" },
                   { "recurring_designer_taskcreator", "Sowieja" },
                   { "filePath_designer_taskcreator", "Stirnpfad" },
                   { "save_designer_taskcreator", "Nasenbeinen" },
                   { "cancel_designer_taskcreator", "Auskippen" },
                   #endregion
                   #region Enum UnitFactors
                   { "seconds_unitfactors_designer_taskcreator", "Deutsche Sekunden" },
                   { "minutes_unitfactors_designer_taskcreator", "Deutsche Minuten" },
                   { "hours_unitfactors_designer_taskcreator", "Deutsche Stunden" },
                   { "days_unitfactors_designer_taskcreator", "Deutsche Tage" },
                   { "weeks_unitfactors_designer_taskcreator", "Deutsche Wochen" },
                   #endregion
               }
            }
        };

        /// <summary>
        /// Gibt die übersetzte Zeichenkette für den angegebenen Sprachcode und Schlüssel zurück.
        /// Falls Platzhalter in der Übersetzung vorhanden sind, werden diese mit den übergebenen Werten ersetzt.
        /// Falls keine Übersetzung gefunden wird, wird der Schlüssel selbst zurückgegeben.
        /// </summary>
        /// <param name="language">Der Sprachcode, z. B. "de", "en", "fr" usw.</param>
        /// <param name="key">Der Schlüssel der Übersetzung, z. B. "welcome".</param>
        /// <param name="args">Optionale Parameter, die in der Übersetzung die Platzhalter {0}, {1} usw. ersetzen.</param>
        /// <returns>Die übersetzte Zeichenkette oder den Schlüssel, wenn keine passende Übersetzung vorhanden ist.</returns>
        public static string GetTranslation(string language, string key, params object[] args)
        {
            if (translations.ContainsKey(language) && translations[language].ContainsKey(key))
            {
                var translationStr = translations[language][key];
                for (int i = 0; i < args.Length; i++)
                {
                    translationStr = translationStr.Replace("{" + i.ToString() + "}", args[i].ToString());
                }
                return translationStr;
            }
            return key;
        }


        public static void ChangeLanguage()
        {
            Console.Clear();
            Console.WriteLine(GetTranslation(CurrentLanguage, "choose_language"));
            Console.WriteLine("[1] Deutsch");
            Console.WriteLine("[2] English");
            Console.WriteLine("[3] Français");
            Console.WriteLine("[4] Italiano");
            Console.WriteLine("[5] Español");
            Console.WriteLine("[6] 中文 (Mandarin)");
            Console.WriteLine("[7] हिंदी (Hindi)");
            Console.WriteLine("[8] Baschding");
            Console.WriteLine("[9] " + GetTranslation(CurrentLanguage, "back_option"));

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CurrentLanguage = "de";
                    break;
                case "2":
                    CurrentLanguage = "en";
                    break;
                case "3":
                    CurrentLanguage = "fr";
                    break;
                case "4":
                    CurrentLanguage = "it";
                    break;
                case "5":
                    CurrentLanguage = "es";
                    break;
                case "6":
                    CurrentLanguage = "zh";
                    break;
                case "7":
                    CurrentLanguage = "hi";
                    break;
                case "8":
                    CurrentLanguage = "bd";
                    break;
                case "9":
                    return;
                default:
                    Console.WriteLine(GetTranslation(CurrentLanguage, "invalid_input"));
                    Thread.Sleep(1500);
                    break;
            }
            SaveSettings();
        }

        private static string SaveSettings()
        {
            string settingsFilePath = "settings.txt";

            string settings = CurrentLanguage;

            File.WriteAllText(settingsFilePath, settings);
            return settings;
        }

        public static string GetCurrentLanguage()
        {
            string settingsFilePath = "settings.txt";

            if (File.Exists(settingsFilePath))
            {
                string[] settings = File.ReadAllLines(settingsFilePath);

                if (settings.Length >= 1)
                {
                    return settings[0].Replace("\n", "").Trim();
                }
            }
            return SaveSettings();
        }
    }
}

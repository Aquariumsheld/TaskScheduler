using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskClasses
{
    /// <summary>
    /// Überklasse für alle Tasks. Individuelle wie vorgefertigte.
    /// </summary>
    public abstract class MainTask
    {
        /// <summary>
        /// Name der Task.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Zeitpunkt zu dem die Task ausgeführt werden soll.
        /// </summary>
        public DateTime ScheduledTime { get; set; }

        /// <summary>
        /// Priorität der Task.
        /// </summary>
        public int Priority { get; set; } // 1 = high, 5 = low

        /// <summary>
        /// Wahrheitswert, ob sich die Task wiederholen soll.
        /// True wenn ja, andernfalls False
        /// </summary>
        public bool IsRecurring { get; set; }

        /// <summary>
        /// Intervall in dem sich die Task wiederholen soll, wenn sie sich wiederholen soll.
        /// </summary>
        public TimeSpan? Interval { get; set; } // Für wiederkehrende Aufgaben

        /// <summary>
        /// Die spezifische Art und Weise, wie eine Task ausgeführt werden soll
        /// </summary>
        public abstract void Execute();
    }
}

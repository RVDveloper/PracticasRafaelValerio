public class Mazoff : Enemigo
{
    public const string BossIcon = "🤦‍♂️";public const string dice = "🎲";public const string Wave = "🌊";public const string Warning = "⚠️";

    public Mazoff() 
        : base($"Mazoff {BossIcon}", 50, 15, 10)
    {
        Program.VibrarConColores(@"
XXXXXXxxxxx++++++++++++++++++++++XXXXXX
XXXXXXxxxxxxxxx&&&$&&&&&+++++++++XXXXXX
XXXXXXxxxxxx+&&x$&X&&&&&&&+++++++XXXXXX
XXXXXXxxxxx&&&&&&&&&&&x+++&x+++++XXXXXX
XXXXXXxxx&&;++++++++++++++;&xx+x+XXXXXX
XXXXXXxx&$X++++++++++;++;;;;XxxxxXXXXXX
XXXXXXxx&$X;;;;x;;;;;;;;;;;;;xxxxXXXXXX
XXXXXXxxX$&;;;;;;;;;;;;;&XX;x&xxxXXXXXX
XXXXXXXx&+&;;;;+&$xX;:;+xxXx+xxxxXXXXXX
XXXXXXXX&&+;;&X;;&&&+;;X+;;;:;&xxXXXXXX
XXXXXX;&+++;;&;;:+;::$;::;::::&xxXXXXXX
XXXXXX+;&X+;::::;x:::;:;:;::;;&xxXXXXXX
XXXXXX$;;:X;;;::;;;:;;;++&+x;;$xxXXXXXX
XXXXXXXX;;$X+;;;;;;+++;;;;;;;;XXXXXXXXX
XXXXXXXXX&;;+;;;;;;;;;;;;;x+;;XXXXXXXXX
XXXXXXXXXX&;X+;;;;;;&xxx&+;;+xXXXXXXXXX
XXXXXXXXXXXXXX;;;;;;;x;++;++XXXXXXXXXXX
XXXXXXXXXXXXXXXX;+++++++++XXXXXXXXXXXXX
XXXXXXXXXXXXXXXX$+++&++++XXXXXXXXXXXXXX
XXXXXX$$XXXXXXXX++X+++$XXXXXXXXXXXXXXXX
XXXXXX$$$$$XXXx+;&x+&+&X$XXXXXXXXXXXXXX");

    Program.PrintWithDelay($"¡Atención! Mazón irrumpe en escena, armado con excusas y cara de 'yo no fui'{BossIcon}",40);
    Program.PrintWithDelay($"El suelo tiembla, al avanzar la Dana ¡ y Mazon entra en modo apagado Mazoff!{BossIcon} llega con promesas vacías! ¿Podrás vencerlo? y Sobrevivir de la Catastrofe?",40);

    }

    public override void UsarHabilidad(Personaje jugador, Random rnd)
    {
        base.UsarHabilidad(jugador, rnd);
        Program.PrintWithDelay($"{Nombre} causa un gran daño con su ataque modo off entra en modo maz!off! y evita que estes preparado y eres afectado por la DANA mortalmente!!{Wave}",40);
        
        if (rnd.Next(1, 5) == 5)
        {
            Program.PrintWithDelay($"¡El ataque de Mazoff hace que no puedas ser rescatado con su habilidad de retrasar alertas!{Wave}", 40);
            jugador.Vida -= 4; 
        }
    }
}
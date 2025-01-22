public class PerroSanchez : Enemigo
{
    public const string BossIcon = "🤵‍♂️";public const string dice = "🎲";public const string Warning = "⚠️";

    public PerroSanchez() 
        : base($"Perro Sánchez {BossIcon}", 50, 15, 10)
    {
        
                Program.VibrarConColores(@"
 ...........:..........
..:&XXXX$&&&&&&&:.....
.&X&$$XXXX&&&&&&&&....
+&&$$&$$&&&&&&&&&&+...
.&::x:::::::::&&&$&...
.;::::;;:::::;&&&$$...
.:::;;;;;;:::::;$$$...
.;:&&;;;;$&&&&;;;+;;..
..;;+x:;;;;;xx;;;;;;..
.+;;;:::;:;+;;;;;;;:..
..:;;;;X;::;;;;;;;::..
..:;;;;;;;;;;;;;;;....
...;;;;;;;;;;;;;;;....
....;;:::;;;;;;;;;....
.....;;;;;;;;;;;;.....
.......;;;:;;:...:$&..
........;;;::....$$$$.
........:;;:....&$$$$$
.......&.::..:.:$$$$&.
......:$....:..$$$$$..
......x&......$$$$$$..
......$:.....&$$$$&:..
.....:::....:$$$$$....
.....$&$&$&&:$$$$.....
....x$$$$$$$;:&$......
....::.::.:.:::.......");


    Program.PrintWithDelay($"{Warning}CUIDADO! Perro Sanchez{BossIcon} ha llegado, luciendo más perdido que nunca", 40);
    Program.PrintWithDelay($"Perro Sanchez{BossIcon} aparece como jefe final ¡Prepárate para la batalla!", 40);


    }

    public override void UsarHabilidad(Personaje jugador, Random rnd)
    {
        base.UsarHabilidad(jugador, rnd);
        Program.PrintWithDelay($"{Nombre} causa un gran daño con su habilidad Incompetencia Subnormal!!",40);
        
        if (rnd.Next(1, 5) == 5)
        {
            Program.PrintWithDelay($"¡ Perro Sánchez activa su habilidad de ineficiencia {BossIcon} |Si necesitan ayuda que la pidan| y hace que no puedas ser rescatado!", 40);
            jugador.Vida -= 3; 
        }
    }
}
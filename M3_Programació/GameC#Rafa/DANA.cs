

public class DANA : Enemigo
{
    public const string BossIcon = "🌊";public const string dice = "🎲";public const string Warning = "⚠️";

    public DANA() 
        : base($"La DANA {BossIcon}", 50, 15, 10)
    {

        Program.VibrarConColores(@"   
                     
                r         
               ain
               rai
              nrain
             rainrai
            nrainrain
           ainrainrain
          rainrainrainr
         ainrainrainrain
        rainrainrainrainr
      ainrainrainrainrainra
    inra nrainrainrainrainrai
  nrain  inrainrainrainrainrain
 rain   nrainrainrainrainrainrai
nrai   inrainrainrainrainrainrain
rai   inrainrainrainrainrainrainr
rain   nrainrainrainrainrainrainr
 rainr  nrainrainrainrainrainrai
  nrain ainrainrainrainrainrain
    rainrainrainrainrainrainr
      rainranirainrainrainr
           ainrainrain");

           Program.PrintWithDelay($"{Warning}ALERTA! Dana ha emergido delante de ti, irradiando una energía que dobla la realidad misma", 40);
           Program.PrintWithDelay($"Esto no es un simulacro! Dana está aquí, y su energía es un tsunami de poder descontrolado Preparate Para intentar Sobrevivir", 40);

    }

    public override void UsarHabilidad(Personaje jugador, Random rnd)
    {
        base.UsarHabilidad(jugador, rnd);
        Program.PrintWithDelay($"{Nombre} causa un enorme daño con un alud e inundacion inesperada!!",40);
        
        if (rnd.Next(1, 5) == 5)
        {
            Program.PrintWithDelay("¡El Deslizamiento del Agua te atrapa y te aplasta con todo su poder ODDIO GG Your Are Fisnished!", 40);
            jugador.Vida -= 4; 
        }
    }


    
}

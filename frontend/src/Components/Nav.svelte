<script>
</script>

<nav class="navbar">
  <div class="navbar-content">
    <h1 class="title"><strong>The webs most <br>
      <i>awesome</i> budget planner!</strong></h1>
    <p class="paragraph">
      Välkommen till världens bästa budgetapp!<br>
      Där din ekonomi blir <strong>enkel</strong>, din framtid <strong>ljusare</strong> och dina mål möjliga att uppnå.<br>
      Upptäck kraften i <strong>smart</strong> budgetering med oss!
  </p>
  </div>
  <div class="card">
    <h2 class="card-title">Hur fungerar det?</h2>
    <div class="card-description">

      <div class="step">
        <h3>1. Fyll i din inkomst</h3>
        <p> 
          Kom ihåg att inkludera alla dina inkomster, inte bara din lön,
          utan även andra källor som bidrag, extrajobb, och passiva
          inkomster.
        </p>
      </div>

      <div class="step">
        <h3>2. Välj en mall</h3>
        <p> 
          Välj en av våra fördefinierade mallar eller skapa din egen
          budgetmall.
        </p>
      </div>

      <div class="step">
        <h3>3. Registrera Dina Utgifter</h3>
        <p> 
          Här kan du lägga till olika utgiftskategorier för att organisera
          dina kostnader. Exempel på kategorier kan vara 'Boende', 'Mat',
          'Transport', 'Fritid', etc.
        </p>
      </div>

      <div class="step">
        <h3>4. Anpassa och Uppdatera</h3>
        <p> 
          När du har lagt till dina inkomster och utgifter, kan du enkelt
          justera belopp och kategorier vid behov. Din totala budget kommer
          att uppdateras automatiskt för att reflektera dessa förändringar.
        </p>
      </div>

    </div>
  </div>
</nav>
<style>

  .navbar {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    text-align: center;
    padding: 1rem;
    background-color: #091f20;
    color: #dff5f6;
  }

  .navbar-content {
    margin: 1rem 0;
  }

  .navbar-content h1 {
    font-size: 2.5rem;
    margin-bottom: 1rem;
  }

  .card {
    width: 100%;
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 4px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    text-align: left;
    margin: 20px 0;
    color: #091f20;
    background-color: #dff5f6;

  }

  .card-description {
    display: flex;
    flex-direction: column;
    align-items: center;
  }

  .step, .card-title {
    margin-bottom: 1rem;
    text-align: center;
  }

  @media (min-width: 768px) {
    .card {
      width: 100%;
    }
  }

  @media (min-width: 1024px) {
    .card {
      width: 100ch;
      display: flex;
      flex-direction: column;
      justify-content: center;
      align-items: center;
      text-align: center;
    }

    .paragraph {
      font-size: var(--fs-500);
    }

    .card-title {
      font-size: var(--fs-500);
      font-weight: 800;
    }
    .card-description {
      width: 65ch;
    }

    .navbar-content {
      max-width: 100%;
    }

    .navbar-content h1 {
      font-size: 5.61rem;
      margin-bottom: 1rem;
    }

    .navbar-content p {
      font-size: 1.333rem;
      margin-bottom: 1rem;
    }
  }

  /* .navbar {
    padding: 1rem;
    background-color: var(--clr-primary);
    color: var(--clr-text);
    font-family: "Poppins", sans-serif;
  }

  .navbar-content {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    max-width: 100%;
    margin: 0 auto;
  }

  .instructions-container {
    display: flex;
    flex-direction: column;
    align-items: center;
    background-color: #dff4f6;
    padding: 1rem;
    width: 100%;
  }

  .step-intro,
  .step-1,
  .step-2,
  .step-3,
  .step-4 {
    text-align: center;
    margin-bottom: 1rem;
  }

  @media (min-width: 768px) {

    .navbar {
      padding: 2rem;
    }

    .instructions-container {
      display: grid;
      grid-template-columns: repeat(3, 1fr);
      gap: 1rem;
      max-width: 800px;
      margin: 0 auto;
    }

    .step-1,
    .step-2,
    .step-3,
    .step-4 {
      display: flex;
      flex-direction: row;
    }
  }

  @media (min-width: 1024px) {
    
    .navbar-content {
      max-width: 800px;
      margin: 0 auto;
    }
  } */


  /* .navbar-content {
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    width: 100%;
  }

  .instructions-container {
    width: 75%;
    display: grid;
    grid-template-columns: 20% 40% 40%;
    grid-template-rows: 1fr 1fr;
    gap: 1rem 1rem;
    padding: 2rem 2rem;
    grid-auto-flow: row;
    grid-template-areas:
      "step-intro step-1 step-2"
      "step-intro step-3 step-4";
    justify-content: center;
    align-content: center;
    justify-items: center;
    align-items: center;
    background-color: #dff4f6;
  }

  .step-intro {
    grid-area: step-intro;
    width: 100%;
    padding: 1rem;
    font-size: 48px;
  }

  .step-1 {
    grid-area: step-1;
    display: grid;
    grid-template-columns: 1fr min(65ch, 100%);
    align-items: center;
    text-align: center;
  }

  .step-2 {
    grid-area: step-2;
    display: grid;
    grid-template-columns: 1fr min(65ch, 100%);
    align-items: center;
    padding: 1rem;
  }

  .step-3 {
    grid-area: step-3;
    display: grid;
    grid-template-columns: 1fr min(65ch, 100%);
    align-items: center;
    padding: 1rem;
  }

  .step-4 {
    grid-area: step-4;
    display: grid;
    grid-template-columns: 1fr min(65ch, 100%);
    align-items: center;
    padding: 1rem;
  }

  .step-title {
    grid-column: 1;
    margin-right: 25px;
    font-size: 82px;
    font-weight: 600;
  }

  .step-paragraph {
    grid-column: 2;
    width: 100%;
    text-align: center;
    align-items: center;
  }

  .step-paragraph p {
    width: 100%;
  } */
</style>

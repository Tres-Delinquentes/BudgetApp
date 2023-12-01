<script>
  export let budgetToDisplay = 0;
  $: console.log("budgettodisplay: " + budgetToDisplay);
  export let budgetTitle = "Name of budget";
</script>

<div class="full-bleed">
  <nav class="navbar">
    <div class="navbar-content">
      <h1 class="display">Budget Appen</h1>
        <p class="p">
          Lorem ipsum dolor sit, amet consectetur adipisicing elit. Non in eum
          distinctio libero adipisci, officia maxime aliquam corrupti iusto architecto
          amet eveniet harum quis quasi sed corporis nemo excepturi quam!
        </p>

        <div class="instructions-container mt-5">
            <div class="step-intro">
              <h2 style="font-weight: 900;">Hur fungerar det?</h2>
            </div>

            <div class="step-1">
              <div class="step-title">
                <h1 class="display">1</h1>
              </div>
              <div class="step-paragraph">
                <h3 class="subdisplay">Fyll i Din Inkomst</h3>
                <p class="p">Kom ihåg att inkludera alla dina inkomster, inte bara din lön, utan även andra källor som bidrag, extrajobb, och passiva inkomster.</p>
              </div>
            </div>

            <div class="step-2">
              <div class="step-title">
                <h1 class="">2</h1>
              </div>
              <div class="step-paragraph">
                <h3 class="subdisplay">Välj en mall</h3>
                <p class="p">Välj en av våra fördefinierade mallar eller skapa din egen budgetmall.</p>
              </div>
            </div>

            <div class="step-3">
              <div class="step-title">
                <h1 class="">3</h1>
              </div>
              <div class="step-paragraph">
                <h3 class="subdisplay">Registrera Dina Utgifter</h3>
                <p class="p">Här kan du lägga till olika utgiftskategorier för att organisera dina kostnader. Exempel på kategorier kan vara 'Boende', 'Mat', 'Transport', 'Fritid', etc.</p>
              </div>
            </div>

            <div class="step-4">
              <div class="step-title">
                <h1 class="">4</h1>
              </div>
              <div class="step-paragraph">
                <h3 class="subdisplay">Anpassa och Uppdatera</h3>
                <p class="p">När du har lagt till dina inkomster och utgifter, kan du enkelt justera belopp och kategorier vid behov. Din totala budget kommer att uppdateras automatiskt för att reflektera dessa förändringar.</p>
              </div>
            </div>
        </div>
      </div>
  </nav>
</div>




<style>

    .navbar {
    padding: 60px;
    max-width: 100%;
    background-color: var(--clr-primary);
    color: var(--clr-text);
    margin-bottom: 1rem;
    font-family: "Poppins", sans-serif;
  }

  .navbar-content {
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
 }



  /* .instructions-container {
    max-width: 100%;
    margin: auto;
    padding: 2rem 0;
    text-align: center;
    background-color: #fff;
    color: #333;
  } */




</style>

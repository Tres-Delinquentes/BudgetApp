<script>
  export let budgetToDisplay = 0;
  $: console.log("budgettodisplay: " + budgetToDisplay);
  export let budgetTitle = "Name of budget";
</script>

<nav class="full-bleed">

  <h1 class="display">Budget Appen</h1>
  <p class="p">
    Lorem ipsum dolor sit, amet consectetur adipisicing elit. Non in eum
    distinctio libero adipisci, officia maxime aliquam corrupti iusto architecto
    amet eveniet harum quis quasi sed corporis nemo excepturi quam!
  </p>
  <input class="budget-title" type="text" bind:value={budgetTitle} />
  <h1 class="subdisplay">Välj ett av våra 3 templates</h1>
  <button on:click={() => (budgetToDisplay = 0)}>1</button>
  <button on:click={() => (budgetToDisplay = 1)}>2</button>
  <button on:click={() => (budgetToDisplay = 2)}>3</button>





    <div class="content-first">

    
    <div class="instructions mt-3">
      <h2>Hur man använder Budgetappen</h2>
      <ol>
        <li><strong>Välj en Mall:</strong> Börja med att välja ett av våra fördefinierade mallar eller skapa din egen budgetmall.</li>
        <li><strong>Fyll i Din Inkomst:</strong> Ange dina inkomstkällor. Kom ihåg att inkludera alla dina inkomster, inte bara din lön, utan även andra källor som bidrag, extrajobb, och passiva inkomster.</li>
        <li><strong>Registrera Dina Utgifter:</strong> Fyll i dina utgifter. Här kan du lägga till olika utgiftskategorier för att organisera dina kostnader. Exempel på kategorier kan vara 'Boende', 'Mat', 'Transport', 'Fritid', etc.</li>
        <li><strong>Lägg till Utgiftskategorier:</strong> Du kan enkelt lägga till nya utgiftskategorier genom att använda 'Lägg till ny kategori'-knappen. Detta ger dig möjligheten att anpassa din budget efter dina unika behov och utgiftsmönster.</li>
        <li><strong>Anpassa och Uppdatera:</strong> När du har lagt till dina inkomster och utgifter, kan du enkelt justera belopp och kategorier vid behov. Din totala budget kommer att uppdateras automatiskt för att reflektera dessa förändringar.</li>
        <li><strong>Övervaka Din Budget:</strong> Använd appen för att regelbundet övervaka din budget. Detta hjälper dig att hålla koll på dina utgifter och gör det lättare att uppnå dina finansiella mål.</li>
      </ol>
      <p>Genom att följa dessa enkla steg kan du skapa och hantera en budget som hjälper dig att hålla koll på dina finanser och planera för framtiden.</p>
    </div>
  </div>

</nav>

<style>
  
 .instructions {
    font-family: Arial, sans-serif;
    max-width: 800px;
    margin: 0 auto;
    padding: 20px;
    background-color: #f8f8f8;
    border-radius: 4px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  }

  .instructions h2 p {
    color: #091e20;
    text-align: center;
  }

  .instructions ol {
    counter-reset: step-counter;
    list-style-type: none;
    padding-left: 0;
  }

  .instructions ol li {
    counter-increment: step-counter;
    margin-bottom: 15px;
  }

  .instructions ol li::before {
    content: counter(step-counter) ". ";
    font-weight: bold;
    color: #091e20;
  }

  .instructions p {
    text-align: center;
    margin-top: 20px;
    font-style: italic;
    color: #333;
  }

  .budget-title {
    border: none;
    box-shadow: none;
    background-color: aqua;
  }
  nav {
    padding: 60px;
    width: 100%;
    background-color: var(--clr-primary);
    color: var(--clr-text);
    margin-bottom: 1rem;
    font-family: "Poppins", sans-serif;
  }

  h1 {
    font-size: var(--fs-900);
    font-weight: 800;
  }

  p {
    color: white;
  }
</style>

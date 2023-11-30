<script>
  export let budgetToDisplay = 0;
  $: console.log("budgettodisplay: " + budgetToDisplay);
  export let budgetTitle = "DIN BUDGET";
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
</nav>

<style>
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

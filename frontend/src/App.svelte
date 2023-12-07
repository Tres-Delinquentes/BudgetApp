<script>
  import FetchBudget from "./Components/Functions/FetchBudget.svelte";
  import Nav from "./Components/Nav.svelte";
  import Accordion from "./Components/Accordion.svelte";
  import Income from "./Components/Income.svelte";
  import ContentRight from "./Components/ContentRight.svelte";
  // import budgetToDisplay from "./Components/Nav.svelte";

  let budgetToDisplay = 0;
  // let budgetTitle;
  let titleForBudget = "";
  let titleDescription = "";
  let budget = { title: titleForBudget, expenses: [], income: {}, description: titleDescription };

  let budgetList = { expenses: [], income: [] };
  $: console.log("budget from app " + budgetList);

  $: budget.description = titleDescription;
  $: budget.title = titleForBudget;

</script>

<FetchBudget bind:budgetList />

<div class="container">
  <nav class="navbar">
    <Nav />
  </nav>

  <div class="main-content">
    {#if budgetList && budgetList.length > 0}
    <div class="left">
      <h1 class="content-display">Dina uppgifter</h1>
        <div class="income-container">
          <Income bind:budget {budgetList} {budgetToDisplay} />
        </div>
        <input
          class="budget-title"
          type="text"
          placeholder="Namn på din budget"
          bind:value={titleForBudget}
        />
      <br />
      <textarea
        rows="4"
        placeholder="Beskrivning av din budget"
        bind:value={titleDescription}
      />      
    <br />
    <div class="choose-budget">
      <p>
        Välj en utav våra tre fördefinierade mallar eller skapa din egna.
      </p>
      <div class="choose-budget-buttons">
        <button on:click={() => (budgetToDisplay = 0)}>Alt 1</button>
        <button on:click={() => (budgetToDisplay = 1)}>Alt 2</button>
        <button on:click={() => (budgetToDisplay = 2)}>Alt 3</button>
        <button on:click={() => (budgetToDisplay = 3)}>Tom</button>
      </div>
    </div>
      <h1 class="content-display">Utgifter</h1>
    <Accordion
      bind:budget
      {budgetList}
      {budgetToDisplay}
      {titleForBudget}/>
      </div>  
      <div class="right">
        <ContentRight {budget} />
      </div>
      {/if}
    </div>
  <footer class="footer">footer</footer>  
</div>

<style>

.container {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

.navbar {
  color: #dff5f6;
  background-color: #091f20;
}

.main-content {
  display: flex;
  flex-direction: column;
  flex: 1;
}

.left {
  width: 100%;
  padding: 1.5rem;
}

.budget-title {
  justify-content: center;
  align-items: center;
  margin: 0.5rem 0;
}

.income-container {
  margin-bottom: 0.5rem;
}

.choose-budget {
  justify-content: center;
  align-items: center;
  text-align: center;
  width: 100%;
  padding: 1rem;
}

.choose-budget-buttons {
  margin-top: 1rem;
}

.right {
  width: 100%;
  padding: 1.5rem;
  border: 2px solid red;
}

.footer {
  background-color: #091f20;
  color: white;
  text-align: center;
  padding: 1rem;
  border-top: 2px solid #091f20;
}

@media (min-width: 768px) {

 .main-content {
    flex-direction: row;
  }

  .left, .right {
    flex: 1;
    padding: 1rem;
  }
}

@media (min-width: 1024px) {

  .left, .right {
    flex: 1; 
    padding: 3.5rem;
  }
}

textarea {
  width: 100%;
  padding: 10px;
  border: 2px solid #091f20;
  border-radius: 4px;
  font-family: inherit;
  font-size: 1em;
  resize: none;
}

  /* .budget-name {
    margin-bottom: 0.5rem;
    margin-top: 0.5rem;
  }

  .button-group {
    text-align: center;
    margin-top: 1rem;
    margin-bottom: 1rem;
  }

  .button-group p {
  } 

 */
</style>


<!-- <main class="wrapper">
  <Nav />
  {#if budgetList && budgetList.length > 0}
    <div class="wrapper">
      <div class="content-first">
        <h1 class="subdisplay">Dina uppgifter</h1>
        <input
          class="budget-name"
          type="text"
          placeholder="Namn på din budget"
          bind:value={titleForBudget}
        /><br />
        <textarea
          class=""
          rows="4"
          placeholder="Beskrivning av din budget"
          bind:value={titleDescription}
        />
        <br />
        <Income bind:budget {budgetList} {budgetToDisplay} />
        <div class="button-group">
          <p class="p mb-3">
            Nedan har vi 4st olika mallar för hur en budget kan se ut, välj
            gärna en eller skapa din egna från en tom mall.
          </p>
          <button on:click={() => (budgetToDisplay = 0)}>Small</button>
          <button on:click={() => (budgetToDisplay = 1)}>Medium</button>
          <button on:click={() => (budgetToDisplay = 2)}>Large</button>
          <button on:click={() => (budgetToDisplay = 3)}>Empty</button>
        </div>
        <h1 class="subdisplay">Utgifter</h1>
        <Accordion
          bind:budget
          {budgetList}
          {budgetToDisplay}
          {titleForBudget}
        />
      </div>
      <div class="content-second">
        <ContentRight {budget} />
      </div>
    </div>
  {/if}
</main> -->
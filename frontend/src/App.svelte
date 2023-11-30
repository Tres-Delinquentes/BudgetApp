<script>
  import FetchBudget from './Components/FetchBudget.svelte'
  import Nav from './Components/Nav.svelte'
  import Accordion from './Components/Accordion.svelte';
  let budget = { expenses: [], income: [] };
</script>

<style>

</style>

<main class="wrapper">
  <Nav />
  <div class="wrapper">
    <div class="content-first">
      <Accordion { budget }/>
    </div>
    <div class="content-second">
  
    </div>
  </div>
  <FetchBudget bind:budget/>
</main>

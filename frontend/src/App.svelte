<script>
  import FetchBudget from './Components/FetchBudget.svelte'
  import Button from './Components/Button.svelte'
  import Nav from './Components/Nav.svelte'
  import Acc from './Components/acc.svelte';
  // import { budget } from './Components/FetchBudget.svelte'
  let budget = { expenses: [], income: [] };
</script>

<style>

</style>

<main class="wrapper">
  <Nav />
  <div class="wrapper">
    <div class="content-first">
      <Acc { budget }/>
    </div>
    <div class="content-second">
  
    </div>
  </div>
  <FetchBudget bind:budget/>
</main>

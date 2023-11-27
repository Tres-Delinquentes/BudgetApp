<script>
  import svelteLogo from './assets/svelte.svg'
  import viteLogo from '/vite.svg'
  import Counter from './lib/Counter.svelte'
  import FetchBudget from './Components/FetchBudget.svelte'
  import Button from './Components/Button.svelte'
    import Nav from './Components/Nav.svelte';
    const name = 'Mattias';
</script>


<Nav />
<main>
  <FetchBudget />
  <Button text="Primär Knapp" variant="primary" />
  <Button text="Sekundär Knapp" variant="pumpkin"/>
  <Button text="Primär Knapp" variant="yellow" />
  <Button text="Sekundär Knapp" variant="pink"/>
  <Button text="Primär Knapp" variant="green" />
  <Button text="Sekundär Knapp" variant="purple"/>
</main>

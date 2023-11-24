<script>
  export let text = 'Klicka här';
  export let onClick = () => {};
  export let variant = 'primary'; // Lägg till en prop för variant
</script>

<style>
  .button {
    padding: 10px 20px;
    color: white;
    border: 2px solid hsl(var(--clr-primary-500));
    border-radius: 12px;
    cursor: pointer;
    font-family: var(--ff-encode);
    font-size: var(--fs-300);
    font-weight: 500;
    /* transition: background-color 0.1s; */
  }

  .primary {
    border: 2px solid hsl(var(--clr-primary-500));
    background-color: hsl(var(--clr-primary-500))
  }

  .primary:hover {
    border: 2px solid hsl(var(--clr-primary-600));
    background-color: hsl(var(--clr-primary-600))
  }

  .pumpkin {
    border: 2px solid hsl(var(--clr-pumpkin-500));
    background-color: hsl(var(--clr-pumpkin-500))
  }

  .pumpkin:hover {
    border: 2px solid hsl(var(--clr-pumpkin-600));
    background-color: hsl(var(--clr-pumpkin-600))
  }

  .yellow {
    border: 2px solid hsl(var(--clr-yellow-500));
    background-color: hsl(var(--clr-yellow-500))
  }

  .yellow:hover {
    border: 2px solid hsl(var(--clr-yellow-600));
    background-color: hsl(var(--clr-yellow-600))
  }

  .pink {
    border: 2px solid hsl(var(--clr-pink-500));
    background-color: hsl(var(--clr-pink-500))
  }

  .pink:hover {
    border: 2px solid hsl(var(--clr-pink-600));
    background-color: hsl(var(--clr-pink-600))
  }

  .green {
    border: 2px solid hsl(var(--clr-green-500));
    background-color: hsl(var(--clr-green-500))
  }

  .green:hover {
    border: 2px solid hsl(var(--clr-green-600));
    background-color: hsl(var(--clr-green-600))
  }

  .purple {
    border: 2px solid hsl(var(--clr-purple-500));
    background-color: hsl(var(--clr-purple-500))
  }

  .purple:hover {
    border: 2px solid hsl(var(--clr-purple-600));
    background-color: hsl(var(--clr-purple-600))
  }

  /* Lägg till fler stilar för andra varianter här */
</style>

<button class="button {variant}" on:click={onClick}>
  {text}
</button>

<!-- Användns på detta sätt:
<Button text="Primär Knapp" variant="primary" on:click={handlePrimaryClick} />
<Button text="Sekundär Knapp" variant="secondary" on:click={handleSecondaryClick} /> -->

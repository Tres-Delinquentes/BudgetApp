<script lang="ts">
  export let small: any = undefined;
  export let disabled = false;


</script>


<style>
  button {
    padding: 10px 20px;
    background-color: #32a8ae;
		color: #091e20;
		border: none;
    border-radius: 12px;
    cursor: pointer;
    font-family: var(--ff-poppins);
    font-size: var(--fs-200);
    font-weight: 400;

  }

  .primary {
    background-color: #32a8ae;
		color: #091e20;
  }

  :global(body.dark-mode) .primary {
    background-color: #51c6cd;
    color: #dff4f6;
  }

  .secondary {
    background-color: #bce8eb;
    color: #091e20;
  }
  :global(body.dark-mode) .secondary {
    background-color: #144043;
    color: #dff4f6;
}

.small {

}

</style>


<!-- <button class={variant} on:click={toggle}>
  <slot/>
</button> -->


<button class:small on:click {disabled}>
  <slot/>
</button>





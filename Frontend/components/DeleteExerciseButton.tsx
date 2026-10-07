"use client";

import { useRouter } from "next/navigation";
import { useState } from "react";
import { removeExerciseFromWorkout } from "@/modules/exercise/actions";

interface DeleteExerciseButtonProps {
  exerciseId: number;
}

export default function DeleteExerciseButton({ exerciseId }: DeleteExerciseButtonProps) {
  const router = useRouter();
  const [isDeleting, setIsDeleting] = useState(false);
  const [error, setError] = useState<string | null>(null);

  async function handleDelete() {
    if (!window.confirm("Delete this saved exercise?")) {
      return;
    }

    try {
      setIsDeleting(true);
      setError(null);
      await removeExerciseFromWorkout(exerciseId);
      router.refresh();
    } catch {
      setError("Failed to delete. Please try again.");
      setIsDeleting(false);
    }
  }

  return (
    <div className="mt-5">
      <button
        type="button"
        onClick={handleDelete}
        disabled={isDeleting}
        className="rounded-lg border border-rose-400/40 px-3 py-2 text-sm font-semibold text-rose-300 transition hover:bg-rose-400/10 disabled:cursor-not-allowed disabled:opacity-70"
      >
        {isDeleting ? "Deleting..." : "Delete"}
      </button>
      {error ? <p className="mt-2 text-sm text-rose-300">{error}</p> : null}
    </div>
  );
}

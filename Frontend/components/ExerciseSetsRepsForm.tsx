"use client";

import { useState } from "react";
import { updateExerciseSetsReps } from "@/services/exerciseServices";

interface ExerciseSetsRepsFormProps {
  exerciseId: number;
  initialSets: number | null;
  initialReps: number | null;
  isLoggedIn: boolean;
}

export default function ExerciseSetsRepsForm({
  exerciseId,
  initialSets,
  initialReps,
  isLoggedIn,
}: ExerciseSetsRepsFormProps) {
  const [sets, setSets] = useState(initialSets ?? 3);
  const [reps, setReps] = useState(initialReps ?? 10);
  const [isSaving, setIsSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  async function handleSave() {
    if (!isLoggedIn) {
      setMessage("Please log in to save your sets and reps.");
      return;
    }

    try {
      setIsSaving(true);
      setMessage(null);
      await updateExerciseSetsReps(exerciseId, sets, reps);
      setMessage("Saved successfully.");
    } catch {
      setMessage("Failed to save. Please try again.");
    } finally {
      setIsSaving(false);
    }
  }

  return (
    <section className="rounded-2xl border border-white/10 bg-white/[0.03] p-5">
      <h2 className="text-xl font-semibold">Workout Setup</h2>
      <p className="mt-1 text-sm text-slate-300">Set your target sets and reps.</p>

      <div className="mt-5 space-y-4">
        <div className="flex items-center justify-between">
          <span className="font-medium text-slate-200">Sets</span>
          <div className="flex items-center gap-2">
            <button
              type="button"
              onClick={() => setSets((value) => Math.max(1, value - 1))}
              className="rounded-lg border border-white/20 bg-white/5 px-3 py-1 transition hover:bg-white/10"
              aria-label="Decrease sets"
            >
              -
            </button>
            <span className="inline-flex min-w-10 justify-center rounded-lg bg-slate-900 px-3 py-1 font-semibold">
              {sets}
            </span>
            <button
              type="button"
              onClick={() => setSets((value) => Math.min(30, value + 1))}
              className="rounded-lg border border-white/20 bg-white/5 px-3 py-1 transition hover:bg-white/10"
              aria-label="Increase sets"
            >
              +
            </button>
          </div>
        </div>

        <div className="flex items-center justify-between">
          <span className="font-medium text-slate-200">Reps</span>
          <div className="flex items-center gap-2">
            <button
              type="button"
              onClick={() => setReps((value) => Math.max(1, value - 1))}
              className="rounded-lg border border-white/20 bg-white/5 px-3 py-1 transition hover:bg-white/10"
              aria-label="Decrease reps"
            >
              -
            </button>
            <span className="inline-flex min-w-10 justify-center rounded-lg bg-slate-900 px-3 py-1 font-semibold">
              {reps}
            </span>
            <button
              type="button"
              onClick={() => setReps((value) => Math.min(100, value + 1))}
              className="rounded-lg border border-white/20 bg-white/5 px-3 py-1 transition hover:bg-white/10"
              aria-label="Increase reps"
            >
              +
            </button>
          </div>
        </div>
      </div>

      <button
        type="button"
        onClick={handleSave}
        disabled={isSaving}
        className="mt-6 w-full rounded-lg bg-sky-500 px-4 py-2 font-semibold text-slate-950 transition hover:bg-sky-400 disabled:cursor-not-allowed disabled:opacity-70"
      >
        {isSaving ? "Saving..." : "Save Sets and Reps"}
      </button>

      {message ? (
        <p className="mt-3 text-sm text-amber-300">{message}</p>
      ) : null}
    </section>
  );
}

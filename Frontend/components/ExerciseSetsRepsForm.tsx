"use client";

import { useState } from "react";
import { saveExerciseSetsReps } from "@/modules/exercise/actions";

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
      await saveExerciseSetsReps(exerciseId, sets, reps);
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
            <input
              type="number"
              min={1}
              max={30}
              value={sets}
              onChange={(e) => {
                const value = Number(e.target.value);
                if(value >= 1 && value <= 30) {
                  setSets(value);
                }
              }}
              className="w-16 rounded-lg border border-white/20 bg-slate-900 px-3 py-1 text-center font-semibold text-slate-200 focus:outline-none focus:ring-2 focus:ring-sky-500"
            />
          </div>
        </div>

        <div className="flex items-center justify-between">
          <span className="font-medium text-slate-200">Reps</span>
          <div className="flex items-center gap-2">
            <input
              type="number"
              min={1}
              max={100}
              value={reps}
              onChange={(e) => {
                const value = Number(e.target.value);
                if(value >= 1 && value <= 100) {
                  setReps(value);
                }
              }}
              className="w-16 rounded-lg border border-white/20 bg-slate-900 px-3 py-1 text-center font-semibold text-slate-200 focus:outline-none focus:ring-2 focus:ring-sky-500"
            />
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

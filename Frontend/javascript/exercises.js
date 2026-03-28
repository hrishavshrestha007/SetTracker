// Exercise Data
        const EXERCISES = [
            // Chest
            { name:'Bench Press',       muscle:'chest',     icon:'fa-arrow-up',       color:'text-orange-400', bg:'bg-orange-500/15', sets:4, reps:8  },
            { name:'Incline DB Press',  muscle:'chest',     icon:'fa-angle-double-up', color:'text-orange-300', bg:'bg-orange-400/15', sets:3, reps:10 },
            { name:'Cable Fly',         muscle:'chest',     icon:'fa-expand-alt',     color:'text-orange-400', bg:'bg-orange-500/15', sets:3, reps:12 },
            { name:'Push-Ups',          muscle:'chest',     icon:'fa-arrow-up',       color:'text-orange-300', bg:'bg-orange-400/15', sets:4, reps:20 },
            // Back
            { name:'Pull-Ups',          muscle:'back',      icon:'fa-arrow-down',     color:'text-blue-400',   bg:'bg-blue-500/15',   sets:4, reps:8  },
            { name:'Barbell Row',       muscle:'back',      icon:'fa-minus',          color:'text-blue-400',   bg:'bg-blue-500/15',   sets:4, reps:8  },
            { name:'Lat Pulldown',      muscle:'back',      icon:'fa-arrow-down',     color:'text-blue-300',   bg:'bg-blue-400/15',   sets:3, reps:12 },
            { name:'Seated Cable Row',  muscle:'back',      icon:'fa-compress-alt',   color:'text-blue-400',   bg:'bg-blue-500/15',   sets:3, reps:12 },
            // Legs
            { name:'Squat',             muscle:'legs',      icon:'fa-sort-amount-down', color:'text-green-400', bg:'bg-green-500/15', sets:4, reps:6  },
            { name:'Romanian DL',       muscle:'legs',      icon:'fa-long-arrow-alt-down', color:'text-green-400', bg:'bg-green-500/15', sets:3, reps:10 },
            { name:'Leg Press',         muscle:'legs',      icon:'fa-chevron-down',   color:'text-green-300',  bg:'bg-green-400/15',  sets:3, reps:12 },
            { name:'Walking Lunges',    muscle:'legs',      icon:'fa-shoe-prints',    color:'text-green-400',  bg:'bg-green-500/15',  sets:3, reps:16 },
            // Shoulders
            { name:'Shoulder Press',    muscle:'shoulders', icon:'fa-angle-double-up', color:'text-purple-400', bg:'bg-purple-500/15', sets:3, reps:10 },
            { name:'Lateral Raises',    muscle:'shoulders', icon:'fa-arrows-alt-h',   color:'text-purple-400', bg:'bg-purple-500/15', sets:4, reps:15 },
            { name:'Face Pulls',        muscle:'shoulders', icon:'fa-compress-alt',   color:'text-purple-300', bg:'bg-purple-400/15', sets:3, reps:15 },
            // Arms
            { name:'Barbell Curl',      muscle:'arms',      icon:'fa-dumbbell',       color:'text-pink-400',   bg:'bg-pink-500/15',   sets:3, reps:10 },
            { name:'Tricep Pushdown',   muscle:'arms',      icon:'fa-arrow-down',     color:'text-pink-400',   bg:'bg-pink-500/15',   sets:3, reps:12 },
            { name:'Hammer Curl',       muscle:'arms',      icon:'fa-dumbbell',       color:'text-pink-300',   bg:'bg-pink-400/15',   sets:3, reps:12 },
            { name:'Skull Crushers',    muscle:'arms',      icon:'fa-minus',          color:'text-pink-400',   bg:'bg-pink-500/15',   sets:3, reps:10 },
            // Core
            { name:'Plank',             muscle:'core',      icon:'fa-minus',          color:'text-yellow-400', bg:'bg-yellow-500/15', sets:3, reps:60 },
            { name:'Cable Crunch',      muscle:'core',      icon:'fa-angle-down',     color:'text-yellow-400', bg:'bg-yellow-500/15', sets:3, reps:15 },
            { name:'Hanging Leg Raise', muscle:'core',      icon:'fa-sort-amount-up', color:'text-yellow-300', bg:'bg-yellow-400/15', sets:3, reps:12 },
        ];

        // Function to create exercise card HTML
        function createExerciseCard(exercise) {
            return `
                <div class="exercise-card" data-muscle="${exercise.muscle}">
                    <button class="add-btn" onclick="addToWorkout('${exercise.name}')">
                        <i class="fas fa-plus"></i>
                    </button>
                    <div class="exercise-header">
                        <div class="exercise-icon ${exercise.bg} ${exercise.color}">
                            <i class="fas ${exercise.icon}"></i>
                        </div>
                        <div class="exercise-info">
                            <h3>${exercise.name}</h3>
                            <span class="muscle-tag">${exercise.muscle}</span>
                        </div>
                    </div>
                    <div class="exercise-stats">
                        <div class="stat">
                            <span class="stat-label">Sets</span>
                            <span class="stat-value">${exercise.sets}</span>
                        </div>
                        <div class="stat">
                            <span class="stat-label">Reps</span>
                            <span class="stat-value">${exercise.reps}</span>
                        </div>
                        <div class="stat">
                            <span class="stat-label">Volume</span>
                            <span class="stat-value">${exercise.sets * exercise.reps}</span>
                        </div>
                    </div>
                </div>
            `;
        }

        // Function to render exercises by muscle group
        function renderExercises(filter = 'all') {
            const container = document.getElementById('exercisesContainer');
            
            if (filter === 'all') {
                // Group by muscle
                const muscles = [...new Set(EXERCISES.map(e => e.muscle))];
                container.innerHTML = muscles.map(muscle => {
                    const muscleExercises = EXERCISES.filter(e => e.muscle === muscle);
                    return `
                        <div class="muscle-section">
                            <h2 class="muscle-title">
                                ${muscle.charAt(0).toUpperCase() + muscle.slice(1)}
                                <span class="muscle-count">${muscleExercises.length} exercises</span>
                            </h2>
                            <div class="exercises-grid">
                                ${muscleExercises.map(createExerciseCard).join('')}
                            </div>
                        </div>
                    `;
                }).join('');
            } else {
                // Show only filtered muscle
                const filtered = EXERCISES.filter(e => e.muscle === filter);
                container.innerHTML = `
                    <div class="exercises-grid">
                        ${filtered.map(createExerciseCard).join('')}
                    </div>
                `;
            }
        }

        // Add to workout function
        function addToWorkout(exerciseName) {
            // Create notification
            const notification = document.createElement('div');
            notification.style.cssText = `
                position: fixed;
                bottom: 24px;
                right: 24px;
                background: linear-gradient(135deg, #22c55e 0%, #16a34a 100%);
                color: white;
                padding: 16px 24px;
                border-radius: 12px;
                font-weight: 600;
                box-shadow: 0 8px 24px rgba(34, 197, 94, 0.3);
                z-index: 1000;
                animation: slideIn 0.3s ease;
            `;
            notification.innerHTML = `<i class="fas fa-check-circle" style="margin-right: 8px;"></i> Added ${exerciseName} to workout`;
            document.body.appendChild(notification);

            setTimeout(() => {
                notification.style.animation = 'slideOut 0.3s ease';
                setTimeout(() => notification.remove(), 300);
            }, 2000);
        }

        // Filter button click handlers
        document.querySelectorAll('.filter-btn').forEach(btn => {
            btn.addEventListener('click', function() {
                document.querySelectorAll('.filter-btn').forEach(b => b.classList.remove('active'));
                this.classList.add('active');
                renderExercises(this.dataset.filter);
            });
        });

        // Add animations
        const style = document.createElement('style');
        style.textContent = `
            @keyframes slideIn {
                from { transform: translateX(100%); opacity: 0; }
                to { transform: translateX(0); opacity: 1; }
            }
            @keyframes slideOut {
                from { transform: translateX(0); opacity: 1; }
                to { transform: translateX(100%); opacity: 0; }
            }
        `;
        document.head.appendChild(style);

        // Initial render
        renderExercises();